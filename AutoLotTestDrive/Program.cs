using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDALApp.EF;
using AutoLotDALApp.Models;
namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MyDataInitializer());
            Console.WriteLine("*****Fun with ADO.NET EF Code First * ****\n");
            using(var context = new AutoLotEntities())
            {
                foreach(var c in context.Inventory)
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
        }
    }
}
