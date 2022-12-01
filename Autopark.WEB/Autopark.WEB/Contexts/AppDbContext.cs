using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autopark.WEB.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int/*, IdentityUserLogin<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>*/>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        protected AppDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
