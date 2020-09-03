using System;

namespace XYZ.InventoryManagementSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
