using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    [Table("webpages_OperationsToRoles")]
    public class OperationsToRoles
    {
        public string RoleName { get; set; }
        public int ResourceId { get; set; }
        public Operations Operations { get; set; }

    }
}
