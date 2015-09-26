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
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(string connectionString)
            : base(connectionString)
        {

        }
        
        public DbSet<Image> ImageSet { get; set; }

        public DbSet<Message> MessageSet { get; set; }

        public DbSet<Attachment> AttachmentSet { get; set; }

        public DbSet<AppSetting> SiteSettingsSet { get; set; }

        public DbSet<Question> QuestionSet { get; set; }

        public DbSet<Category> CategorySet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new AppSettingMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            //modelBuilder.Configurations.Add(new RoomMap());
        }

    
    }
}
