using Autopark.DAL.Entities;
using Autopark.WEB.Entities;

namespace Autopark.WEB.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int DiscountId { get; set; }

        public DateTime? Date { get; set; }
        public VCar? Car { get; set; }
        public Discount? Discount { get; set; }
        public VCustomer? Customer { get; set; }
        public VEmployee? Employee { get; set; }
    }
}
