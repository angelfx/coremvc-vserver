using System;
using System.Collections.Generic;
using System.Text;
using VServers.Models.DTO;


namespace VServers.Abstract
{
    public interface ILogic : IDisposable
    {
        /// <summary>
        /// Добавление нового сервера
        /// </summary>
        /// <param name="server"></param>
        void AddServer(VirtualServerDTO server);

        /// <summary>
        /// Получение всех серверов
        /// </summary>
        /// <returns></returns>
        IEnumerable<VirtualServerDTO> GetServers();

        /// <summary>
        /// Получение общего времени работы серверов. Максимальное время создания.
        /// Первый сопособ получения. Сначала получаем все сервера и уже в логике вычисляем
        /// </summary>
        /// <returns></returns>
        DateTime GetTotalTime();

        /// <summary>
        /// Получение общего времени работы серверов. Максимальное время создания.
        /// Второй сопособ получения. Сразу получаем нуженые данные. Минимизируем запрос к базе данных
        /// Счетаю этот способ более правильным
        /// </summary>
        /// <returns></returns>
        DateTime GetTotalTime2();

        /// <summary>
        /// Помечаем сервер на удаление
        /// </summary>
        /// <param name="id"></param>
        void MarkToDelete(int id);

        /// <summary>
        /// Удаление серверов, которые помечены на удаление
        /// </summary>
        /// <param name="id"></param>
        void MarkAsDeleted();
    }
}
