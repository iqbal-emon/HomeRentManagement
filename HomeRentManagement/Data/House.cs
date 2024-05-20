using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HomeRentManagement.Data
{
    public class House
    {
        [Key]
        public int HouseID { get; set; }
        public string HouseName { get; set; }
        public string HouseAddress { get; set; }

        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public virtual Floor Floors { get; set; }
    }

}
