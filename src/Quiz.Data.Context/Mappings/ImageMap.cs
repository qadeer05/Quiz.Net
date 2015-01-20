using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Data.Context.Mappings
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {

        public ImageMap()
        {
            // Primary Key
            HasKey(t => t.ImageGuid);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(255);

            Property(t => t.Extension).HasMaxLength(10);

            // Table & Column Mappings
            ToTable("Image");
            Property(t => t.ImageGuid).HasColumnName("ImageGuid");
        }

    }
}
