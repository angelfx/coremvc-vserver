using System;
using System.Collections.Generic;
using System.Text;
using VServers.Abstract;
using VServers.Entities;
using VServers.BLL.Repositories;

namespace VServers.BLL
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IDALContext db;
        private VirtualServerRepository virtualServerRepository;

        public EFUnitOfWork(IDALContext context)
        {
            db = context;
        }

        public IVirtualServerRepository VirtualServers
        {
            get
            {
                if (virtualServerRepository == null)
                    virtualServerRepository = new VirtualServerRepository(db);
                return virtualServerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
