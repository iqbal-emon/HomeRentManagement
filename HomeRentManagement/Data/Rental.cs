using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class Rental
    {
        [Key]
        public int RentID { get; set; }

        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        public virtual Unit Unit { get; set; }

        public int TenantID { get; set; }
        [ForeignKey("TenantID")]
        public virtual Tenant Tenant { get; set; }

        public decimal ElectricityBill { get; set; }
        public decimal GasBill { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal Rent { get; set; }

        public decimal Total
        {
            get
            {
                return ElectricityBill + GasBill + ServiceCharge + Rent;
            }
            // Since Total is a read-only property, it won't be mapped to a column in the database
            // Hence, there is no need for a setter here.
        }
        public DateTime RentDate { get; set; }
    }

}
