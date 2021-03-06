﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.EntityFramework;
using Quiz.Data.Infrastructure.Repositories;
using Quiz.Domain;


namespace Quiz.Data.Infrastructure.Repositories
{
    public class OperationsToRolesRepository: RepositoryBase<OperationsToRoles>
    {
        public OperationsToRolesRepository(UserDbContext context) : base(context) { }
    }
}
