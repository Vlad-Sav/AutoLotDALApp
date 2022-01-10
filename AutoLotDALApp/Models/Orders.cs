using AutoLotDALApp.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AutoLotDALApp.Models
{
    public partial class Orders: EntityBase
    {
     
      

        public int CustId { get; set; }

        public int CarId { get; set; }
        [ForeignKey(nameof(CustId))]
        public virtual Customers Customers { get; set; }
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Car { get; set; }
    }
}
