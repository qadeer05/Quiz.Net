using System;
using System.Data.Entity;

namespace Quiz.Data.Infrastructure.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        T Context { get; }
        void Save();
    }
}