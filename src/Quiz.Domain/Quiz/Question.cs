using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    public class Question
    {
        public int Id { get; set; }

        [ForeignKey("Category")] 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public string QuestionString { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public byte Answer { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
