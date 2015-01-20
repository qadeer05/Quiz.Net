using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain;

namespace Quiz.Data.Context.Mappings
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {

        public MessageMap()
        {
            HasKey(t => t.Id);

            ToTable("Message");
        }

    }
}
