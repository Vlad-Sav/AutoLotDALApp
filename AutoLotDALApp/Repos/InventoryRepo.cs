using AutoLotDALApp.Models;
using AutoLotDALApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDALApp.Repos
{
    public class InventoryRepo: BaseRepo<Inventory>
    {

        public override List<Inventory> GetAll()
            => Context.Inventory.OrderBy(x => x.PetName).ToList();
    }
}
