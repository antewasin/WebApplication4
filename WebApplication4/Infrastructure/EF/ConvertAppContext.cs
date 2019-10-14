namespace WebApplication4.Infrastructure.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication4.Models;

    public class ConvertAppContext : DbContext
    {

        public ConvertAppContext()
            : base("name=ConvertAppContext")
        {
            if (this.Currencies.Count() == 0)
            {
                ClientRequests cr = new ClientRequests();

                foreach (var current in cr.GetCurrentsAndRates())
                {
                    this.Currencies.AddOrUpdate(current);
                    this.SaveChanges();
                }
            }
        }


        public virtual DbSet<ClientRequest> Requests { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }

    }
}
