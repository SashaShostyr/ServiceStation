using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ServiceStation.Models
{
    public class ServiceStationContext :DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Lifecycle> Lifecycles { get; set; }
    }
}