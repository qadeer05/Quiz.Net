﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.Repositories;
using Quiz.Infrastructure;

namespace Quiz.Data.Infrastructure.UnitOfWork
{
    public class UserUnitOfWork : IDisposable
    {
        private UserDbContext _context = new UserDbContext(Constants.DefaultConnectionString);
        private UserProfileRepository _userProfileRepository;
        private MembershipRepository _membershipRepository;
        private ResourceRepository _resourceRepository;
        private OperationsToRolesRepository _operationsToRolesRepository;

        public UserUnitOfWork()
        {
            _userProfileRepository = new UserProfileRepository(_context);
            _membershipRepository = new MembershipRepository(_context);
            _operationsToRolesRepository = new OperationsToRolesRepository(_context);
            _resourceRepository = new ResourceRepository(_context);
        }

        public UserProfileRepository UserProfileRepository
        {
            get { return _userProfileRepository; }
        }

        public MembershipRepository MembershipRepository
        {
            get { return _membershipRepository; }
        }

        public ResourceRepository ResourceRepository
        {
            get { return _resourceRepository; }
        }

        public OperationsToRolesRepository OperationsToRolesRepository
        {
            get { return _operationsToRolesRepository; }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public UserDbContext Context
        {
            get { return _context; }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
