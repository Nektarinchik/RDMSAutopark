using Autopark.DAL.Entities;
using Autopark.WEB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autopark.DAL.EF
{
    public partial class RdbmsdbContext : AppDbContext
    {
        public RdbmsdbContext(DbContextOptions<RdbmsdbContext> options)
            : base(options)
        { }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<CarShowroom> CarShowrooms { get; set; }

        public virtual DbSet<CarType> CarTypes { get; set; }

        public virtual DbSet<CustomerEmployee> CustomerEmployees { get; set; }

        public virtual DbSet<CustomerType> CustomerTypes { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Generation> Generations { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<VCar> VCars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-G9GG5EN;Database=RDBMSDb;TrustServerCertificate=True;User ID=nikita;Password=nikita;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<VCar>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vCars");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Cars_Id");

                entity.HasOne(d => d.CarShowroom).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarShowroomId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.CarType).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Generation).WithMany(p => p.Cars).HasForeignKey(d => d.GenerationId);
            });

            modelBuilder.Entity<CarShowroom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CarShowrooms_Id");

                entity.Property(e => e.Phone).HasMaxLength(40);
                entity.Property(e => e.Title).HasMaxLength(40);
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CarTypes_Id");

                entity.Property(e => e.Title).HasMaxLength(40);
            });

            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.HasKey(e => e.Id).HasName("PK_Customers_Id");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
            //        .HasForeignKey(d => d.CustomerTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.IdNavigation).WithOne(p => p.Customer)
            //        .HasForeignKey<Customer>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            modelBuilder.Entity<CustomerEmployee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CustomerEmployee_Id");

                entity.ToTable("CustomerEmployee");

                entity.HasIndex(e => new { e.EmployeeId, e.CustomerId }, "UQ_EmployeeId_CustomerId").IsUnique();

                entity.HasOne(d => d.Customer).WithMany("CustomerEmployees1")
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerEmployee_Customer_CustomerId");

                entity.HasOne(d => d.Employee).WithMany("CustomerEmployees2")
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CustomerEmployee_Employee_EmployeeId");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CustomerTypes_Id");

                entity.Property(e => e.Title).HasMaxLength(40);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Discounts_Id");

                entity.Property(e => e.Title).HasMaxLength(40);
            });

            modelBuilder.Entity<Generation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Generations_Id");

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Model).WithMany(p => p.Generations).HasForeignKey(d => d.ModelId);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Logs_Id");

                entity.Property(e => e.LogMessage).HasMaxLength(256);
                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerUser).WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Manufacturers_Id");

                entity.Property(e => e.Title).HasMaxLength(40);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Models_Id");

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Manufacturer).WithMany(p => p.Models).HasForeignKey(d => d.ManufacturerId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Orders_Id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Car).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.CustomerEmployee).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerEmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
