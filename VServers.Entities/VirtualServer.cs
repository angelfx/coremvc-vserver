using System;

namespace VServers.Entities
{
    public class VirtualServer
    {
        public VirtualServer()
        {
            CreateDateTime = DateTime.Now;
            SelectedForRemove = false;
            Deleted = false;
        }
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? RemoveDateTime { get; set; }

        public bool SelectedForRemove { get; set; }

        public bool Deleted { get; set; }
    }
}
