using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace VServers.MVC.Models
{
    public class TableVirtualServerViewModel
    {
        private VServers.Abstract.ILogic _logic;

        public TableVirtualServerViewModel(VServers.Abstract.ILogic logic)
        {
            _logic = logic;
        }

        public DateTime CurrentTime { get { return DateTime.Now; } }

        public TimeSpan UpTime
        {
            get
            {
                if (Servers.Any(x => !x.Deleted))
                    return (DateTime.Now - Servers.Where(x => !x.Deleted).Max(x => x.CreateDateTime));
                else
                    return TimeSpan.MinValue;
            }
        }

        public IEnumerable<VirtualServerViewModel> Servers { get { return this.GetServers(); } }

        public void AddServer(VirtualServerViewModel server)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VirtualServerViewModel, VServers.Models.DTO.VirtualServerDTO>());
            var mapper = config.CreateMapper();
            _logic.AddServer(mapper.Map<VServers.Models.DTO.VirtualServerDTO>(server));
        }

        public void AddServer()
        {
            var server = new VServers.Models.DTO.VirtualServerDTO
            {
                CreateDateTime = DateTime.Now,
                Deleted = false,
                RemoveDateTime = null,
                SelectedForRemove = false
            };

            _logic.AddServer(server);
        }

        public void MarkToDelete(int id)
        {
            _logic.MarkToDelete(id);
        }

        public void RemoveServers()
        {
            _logic.MarkAsDeleted();
        }

        private IEnumerable<VirtualServerViewModel> GetServers()
        {
            var serversDTO = _logic.GetServers();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VServers.Models.DTO.VirtualServerDTO, VirtualServerViewModel>());
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<VirtualServerViewModel>>(serversDTO);
        }
    }
}
