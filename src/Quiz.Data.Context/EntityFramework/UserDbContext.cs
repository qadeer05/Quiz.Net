using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Data.Context.Mappings;
using Quiz.Domain;

namespace Quiz.Data.Context.EntityFramework
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<OperationsToRoles> OperationsToRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ResourceMap());
            modelBuilder.Configurations.Add(new OperationsToRolesMap());
        }
    }
}