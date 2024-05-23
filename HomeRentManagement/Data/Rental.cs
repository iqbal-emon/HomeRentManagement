using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class Rental
    {
        [Key]
        public int RentID { get; set; }

        public int TenantID { get; set; }
        [ForeignKey("TenantID")]
        public virtual Tenant Tenant { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
      public decimal totalRent { get; set; }
        public DateTime RentDate { get; set; }
    }

}
