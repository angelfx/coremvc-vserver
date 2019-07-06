using System;
using VServers.Models.DTO;
using VServers.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace VServers.BLL.Logic
{
    public class Logic : VServers.Abstract.ILogic
    {
        protected VServers.Abstract.IUnitOfWork uow;
        private bool disposed = false;

        public Logic(VServers.Abstract.IUnitOfWork uwork)
        {
            uow = uwork;
        }

        /// <summary>
        /// Добавление нового сервера
        /// </summary>
        /// <param name="server"></param>
        public void AddServer(VirtualServerDTO server)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VirtualServerDTO, VirtualServer>());

            var mapper = config.CreateMapper();
            var model = mapper.Map<VirtualServer>(server);

            uow.VirtualServers.Create(model);
            uow.Save();
        }

        /// <summary>
        /// Получение всех серверов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VirtualServerDTO> GetServers()
        {
            var servers = uow.VirtualServers.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<VirtualServer, VirtualServerDTO>());
            var mapper = config.CreateMapper();
            var model = mapper.Map<List<VirtualServerDTO>>(servers);

            return model;
        }

        /// <summary>
        /// Получение общего времени работы серверов. Максимальное время создания.
        /// Первый сопособ получения. Сначала получаем все сервера и уже в логике вычисляем
        /// </summary>
        /// <returns></returns>
        public DateTime GetTotalTime()
        {
            var servers = uow.VirtualServers.GetAll();
            return servers.Where(x => !x.Deleted).Max(x => x.CreateDateTime);
        }

        /// <summary>
        /// Получение общего времени работы серверов. Максимальное время создания.
        /// Второй сопособ получения. Сразу получаем нуженые данные. Минимизируем запрос к базе данных
        /// Счетаю этот способ более правильным
        /// </summary>
        /// <returns></returns>
        public DateTime GetTotalTime2()
        {
            return uow.VirtualServers.GetMaxUpTime();
        }

        /// <summary>
        /// Помечаем сервер на удаление
        /// </summary>
        /// <param name="id"></param>
        public void MarkToDelete(int id)
        {
            uow.VirtualServers.MarkToDelete(id);
            uow.Save();
        }

        /// <summary>
        /// Удаляем сервер. Сервер уаляем не физически из БД, а ставим пометку.
        /// </summary>
        /// <param name="id"></param>
        public void MarkAsDeleted()
        {
            uow.VirtualServers.MarkAsDeleted();
            uow.Save();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                uow.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
