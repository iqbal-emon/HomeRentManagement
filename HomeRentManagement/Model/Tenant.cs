using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Model
{
    public class Tenant
    {
        [Key]
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }

        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        public virtual ICollection<Unit> Unit { get; set; }

    }

}
