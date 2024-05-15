using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Model
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        public virtual Unit Unit { get; set; }

        public int TenantID { get; set; }
        [ForeignKey("TenantID")]
        public virtual Tenant Tenant { get; set; }
    }


}
