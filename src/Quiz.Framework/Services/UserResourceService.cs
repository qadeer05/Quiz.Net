using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Quiz.Data.Infrastructure.UnitOfWork;
using Quiz.Domain;

namespace Quiz.Framework.Services
{
    public static class UserResourceService
    {
        public static int AddResource(int id, string name, Operations operations)
        {
            UserUnitOfWork uow = new UserUnitOfWork();
            Resource resource = new Resource()
            {
                Id = id,
                Name = name,
                Operations = operations
            };

            uow.ResourceRepository.Insert(resource);
            uow.Save();
            return resource.Id;
        }

        public static void MapOperationToRole(int resourceId, Operations operation, string role)
        {
            UserUnitOfWork uow = new UserUnitOfWork();
            OperationsToRoles o2r = new OperationsToRoles()
            {
                ResourceId = resourceId,
                Operations = operation,
                RoleName = role
            };
            uow.OperationsToRolesRepository.Insert(o2r);
            uow.Save();
        }

        public static bool Authorize(string userName, int resourceId, Operations operation)
        {
            bool authorized = false;

            var roleProvider = (WebMatrix.WebData.SimpleRoleProvider)Roles.Provider;
            string[] roles = roleProvider.GetRolesForUser(userName);
            UserUnitOfWork uow = new UserUnitOfWork();
            foreach (string role in roles)
            {
                int count = uow.OperationsToRolesRepository.Get(o => o.RoleName == role && o.ResourceId == resourceId &&
                     (o.Operations & operation) != 0).Count();
                if (count > 0)
                {
                    authorized = true;
                    break;
                }
            }
            return authorized;
        }

        public static bool Authorize(int resourceId, Operations operation, string[] roles)
        {
            bool authorized = false;

            UserUnitOfWork uow = new UserUnitOfWork();
            foreach (string role in roles)
            {
                int count = uow.OperationsToRolesRepository.Get(o => o.RoleName == role && o.ResourceId == resourceId &&
                     (o.Operations & operation) != 0).Count();
                if (count > 0)
                {
                    authorized = true;
                    break;
                }
            }
            return authorized;
        }

        public static string GetRolesAsCsv(int resourceId, Operations operation)
        {
            string rolesCsv = string.Empty;
            UserUnitOfWork uow = new UserUnitOfWork();
            var roles = uow.OperationsToRolesRepository.Get(o => o.ResourceId == resourceId &&
                (o.Operations & operation) != 0).Select(o => o.RoleName).Distinct();
            bool firstItem = true;
            foreach (string role in roles)
            {
                if (firstItem)
                {
                    rolesCsv += role;
                    firstItem = false;
                }
                else
                {
                    rolesCsv += "," + role;
                }
            }
            return rolesCsv;

        }

    }
}
