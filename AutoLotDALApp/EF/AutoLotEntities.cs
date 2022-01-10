using AutoLotDALApp.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using AutoLotDALApp.Interception;


namespace AutoLotDALApp.EF
{
    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            // DbInterception.Add(new ConsoleWriterInterceptor());
            //DatabaseLogger.StartLogging();
            // DbInterception.Add(DatabaseLogger);
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }
        private void OnObjectMaterialized(object sender,
          System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {

        }
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Inventory>()
            .HasMany(e => e.Orders)
            .WithRequired(e => e.Car)
            .WillCascadeOnDelete(false);

        }
        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }
        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
        }
      

    }
}
