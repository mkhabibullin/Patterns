using System;

namespace VisitorBetterImpl.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Add(object entity);
        void SaveChanges();
    }
}
