using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HomeRentManagement.Data
{
    public class BillGenerate
    {
        [Key]
        public int BillingID { get; set; }
        [Required]
        public decimal ElectricityBill { get; set; }
        [Required]
        public decimal GasBill { get; set; }
        public decimal ServiceCharge { get; set; }
        public int TenantID { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        [ForeignKey("TenantID")]
        public decimal? TotalRent { get; set; }

        public decimal Total
        {
            get
            {
                return ElectricityBill + GasBill + ServiceCharge + Tenant.Unit.Rent;
            }
            // Since Total is a read-only property, it won't be mapped to a column in the database
            // Hence, there is no need for a setter here.
        }
        public virtual Tenant? Tenant { get; set; }
    }
}
