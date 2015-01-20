using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Infrastructure.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : DbContext
    {
        TContext Context { get; }
        void Save();
    }
}
