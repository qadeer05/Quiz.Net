using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Data.Context.Mappings
{
    public class AppSettingMap : EntityTypeConfiguration<AppSetting>
    {

        public AppSettingMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Setting).IsRequired().HasMaxLength(200);

            Property(t => t.Description).IsRequired().HasMaxLength(500);

            Property(t => t.Value).IsRequired().HasMaxLength(2000);

            // Table & Column Mappings
            ToTable("SiteSetting");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Setting).HasColumnName("Setting");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Value).HasColumnName("Value");
        }

    }
}
