using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class Tenant
    {
        [Key]
        public int TenantID { get; set; }
        public string? TenantName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdCardNumber { get; set; }
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        public virtual User? Owner { get; set; }
        public int HomeId { get; set; }
        [ForeignKey("HomeId")]
        public virtual House? House { get; set; }

        public virtual Unit? Unit { get; set; }

    }

}
