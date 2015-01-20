using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Data.Context.Mappings
{
    public class ResourceMap : EntityTypeConfiguration<Resource>
    {
        internal ResourceMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(e => e.Name).IsVariableLength().HasMaxLength(100).IsRequired();
        }
    }
}
