using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{

    public class Floor
    {
        [Key]
        public int FloorID { get; set; }
        public int FloorNumber { get; set; }

        public int HouseID { get; set; }
        [ForeignKey("HouseID")]
        public virtual House House { get; set; }

    }

}
