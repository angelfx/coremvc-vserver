using System;
using System.Collections.Generic;
using System.Text;
using VServers.Entities;
using VServers.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VServers.BLL.Repositories
{
    public class VirtualServerRepository : AbstractRepository<VirtualServer>, IVirtualServerRepository
    {
        public VirtualServerRepository(IDALContext context) : base(context)
        {
        }

        //public IEnumerable<VirtualServer> GetAll()
        //{
        //    return db.VirtualServers;
        //}

        //public VirtualServer Get(int id)
        //{
        //    return db.VirtualServers.Find(id);
        //}

        //public void Create(VirtualServer server)
        //{
        //    db.VirtualServers.Add(server);
        //}

        //public void Update(VirtualServer server)
        //{
        //    db.VirtualServers.Update(server);

        //}

        //public IEnumerable<VirtualServer> Find(Func<VirtualServer, Boolean> predicate)
        //{
        //    return db.VirtualServers.Where(predicate).ToList();
        //}

        //public void Delete(int id)
        //{
        //    VirtualServer server = db.VirtualServers.Find(id);
        //    if (server != null)
        //        db.VirtualServers.Remove(server);
        //}

        public void MarkToDelete(int id)
        {
            var vs = db.VirtualServers.Find(id);
            if (vs != null)
            {
                vs.SelectedForRemove = true;
                db.VirtualServers.Update(vs);
            }
        }

        public void MarkAsDeleted()
        {
            foreach (var item in db.VirtualServers.Where(x => x.SelectedForRemove && !x.Deleted))
            {
                item.Deleted = true;
                item.RemoveDateTime = DateTime.Now;
                db.VirtualServers.Update(item);
            }
        }

        public DateTime GetMaxUpTime()
        {
            return db.VirtualServers.Where(x => !x.Deleted).Max(x => x.CreateDateTime);
        }
    }
}
