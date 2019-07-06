using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VServers.MVC.Models
{
    public class VirtualServerViewModel
    {
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? RemoveDateTime { get; set; }

        public bool SelectedForRemove { get; set; }

        public bool Deleted { get; set; }
    }
}
