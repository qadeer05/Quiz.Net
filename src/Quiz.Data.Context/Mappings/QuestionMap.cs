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
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.QuestionString).IsRequired().HasMaxLength(1000);

            Property(t => t.Option1).IsRequired().HasMaxLength(200);
            Property(t => t.Option2).IsRequired().HasMaxLength(200);
            Property(t => t.Option3).IsRequired().HasMaxLength(200);
            Property(t => t.Option4).IsRequired().HasMaxLength(200);

            Property(t => t.Answer).IsRequired();

            // Table & Column Mappings
            ToTable("QuestionBank");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.QuestionString).HasColumnName("Question");
            Property(t => t.Option1).HasColumnName("Option1");
            Property(t => t.Option2).HasColumnName("Option2");
            Property(t => t.Option3).HasColumnName("Option3");
            Property(t => t.Option4).HasColumnName("Option4");
            Property(t => t.Answer).HasColumnName("Answer");

        }
    }
}
