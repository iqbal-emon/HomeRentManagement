using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Model
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitNumber { get; set; }

        public int FloorID { get; set; }
        [ForeignKey("FloorID")]
        public virtual Floor Floor { get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; }
    }

}
