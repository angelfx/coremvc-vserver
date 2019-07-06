using System;
using System.Collections.Generic;
using System.Text;

namespace VServers.Models.DTO
{
    public class VirtualServerDTO
    {
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? RemoveDateTime { get; set; }

        public bool SelectedForRemove { get; set; }

        public bool Deleted { get; set; }
    }
}
