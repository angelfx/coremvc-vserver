using System;
using System.Collections.Generic;
using System.Text;
using VServers.Entities;

namespace VServers.Abstract
{
    public interface IVirtualServerRepository : IRepository<VirtualServer>
    {
        /// <summary>
        /// Пометить сервер на удаление
        /// </summary>
        /// <param name="id">ИД сервера в БД</param>
        void MarkToDelete(int id);

        /// <summary>
        /// Удаляет сервер, который помечен на удаление
        /// </summary>
        /// <param name="id">Ид сервера в БД</param>
        void MarkAsDeleted();

        /// <summary>
        /// Получение времени в течении которого живет сервер с максимальным аптаймом
        /// </summary>
        /// <returns></returns>
        DateTime GetMaxUpTime();
    }
}
