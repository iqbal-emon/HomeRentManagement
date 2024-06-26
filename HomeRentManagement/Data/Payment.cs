﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public string? PaymentMonth { get; set; }

        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        public virtual Unit Unit { get; set; }

        public int TenantID { get; set; }
        [ForeignKey("TenantID")]
        public virtual Tenant Tenant { get; set; }
    }


}
