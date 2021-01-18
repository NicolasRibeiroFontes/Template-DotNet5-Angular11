using System;

namespace Template.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity model);
        bool Update(TEntity model);
        bool Delete(TEntity model);
    }
}
