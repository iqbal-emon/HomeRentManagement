using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public virtual Tenant? Tenant { get; set; }
    }
}
