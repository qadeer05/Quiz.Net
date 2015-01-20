using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;

namespace Quiz.Data.Infrastructure.UnitOfWork
{
    public abstract class BaseUnitOfWork : IDisposable
    {

        private bool _disposed;

        protected BaseUnitOfWork(QuizDbContext context)
        {
            Context = context;
        }

        public QuizDbContext Context { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void Dispose(bool disposing)
        {
            if (Context != null && !_disposed && disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //TODO: Error Logging
                throw;
            }
        }

    }
}
