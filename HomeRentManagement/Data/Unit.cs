using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string unitName { get; set; }
        public int  BedRoom{ get; set; }
        public int WashRoom { get; set; }
        public int Rent { get; set; }
        public int FlolorNu { get; set; }

        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }

}
