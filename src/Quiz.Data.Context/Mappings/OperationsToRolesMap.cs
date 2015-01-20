using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Data.Context.Mappings
{
    public class OperationsToRolesMap : EntityTypeConfiguration<OperationsToRoles>
    {
        internal OperationsToRolesMap()
        {
            this.HasKey(e => new { e.ResourceId, e.RoleName });
            this.Property(e => e.RoleName).IsVariableLength().HasMaxLength(256).IsRequired();
        }
    }
}
