using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VServers.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace VServers.DAL.LocalDB.Concrete
{
    public class VServersContext : DbContext, VServers.Abstract.IDALContext
    {
        public DbSet<VirtualServer> VirtualServers { get; set; }

        public VServersContext(DbContextOptions<VServersContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
