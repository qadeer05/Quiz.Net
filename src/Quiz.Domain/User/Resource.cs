using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    [Table("webpages_Resource")]
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Operations Operations { get; set; }
    }
}
