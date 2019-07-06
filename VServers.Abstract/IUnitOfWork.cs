using System;
using System.Collections.Generic;
using System.Text;
using VServers.Entities;
using VServers.Abstract;

namespace VServers.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IVirtualServerRepository VirtualServers { get; }

        void Save();
    }
}
