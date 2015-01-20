using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;
using Quiz.Infrastructure;

namespace Quiz.Data.Context.EntityFramework
{
    public class ContextInitailizer : DropCreateDatabaseAlways<QuizDbContext> {

        private const string HashedPassword = "B23046048EF67A365E069BB82CF801B708ED344D";

        protected override void Seed(QuizDbContext context)
        {
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UIX_USER_UserName ON [User] (UserName)");
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UIX_USER_UserEmail ON [User] (Email)");
            /*
            context.Users.AddOrUpdate(u => u.UserName,

                                    new User("system", HashedPassword, "system@qviz.net")
                                    {
                                          UserGuid = new Guid(Constants.SystemUserGuid),
                                          Roles = new List<Role> {
                                              new Role {Name = Constants.SystemRole, SystemRole = true}
                                          },
                                          LastActivity = DateTime.UtcNow,
                                          LastLogin = DateTime.UtcNow,
                                          LastPasswordChange = DateTime.UtcNow,
                                          LastLockout = DateTime.UtcNow.AddYears(-10),
                                          CreatedBy = new Guid(Constants.SystemUserGuid),
                                          CreatedOn = DateTime.UtcNow,
                                          UpdatedBy = new Guid(Constants.SystemUserGuid),
                                          UpdatedOn = DateTime.UtcNow,
                                      },


                                      new User("admin", HashedPassword, "admin@qviz.net")
                                      {
                                          UserGuid = new Guid(Constants.AdminUserGuid),
                                          Roles = new List<Role> {
                                              new Role {Name = Constants.AdminRole, SystemRole = true}
                                          },
                                          LastActivity = DateTime.UtcNow,
                                          LastLogin = DateTime.UtcNow,
                                          LastPasswordChange = DateTime.UtcNow,
                                          LastLockout = DateTime.UtcNow.AddYears(-10),
                                          CreatedBy = new Guid(Constants.SystemUserGuid),
                                          CreatedOn = DateTime.UtcNow,
                                          UpdatedBy = new Guid(Constants.SystemUserGuid),
                                          UpdatedOn = DateTime.UtcNow,
                                      });

            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Name = "System", SystemRole = false },
                new Role { Name = "Admin", SystemRole = false },
                new Role { Name = "User", SystemRole = false }
                );
            */
            base.Seed(context);
        }

    }
}
