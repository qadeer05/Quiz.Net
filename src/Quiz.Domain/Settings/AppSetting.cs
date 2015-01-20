using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string Setting { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public bool IsCustom { get; set; }
    }
}
