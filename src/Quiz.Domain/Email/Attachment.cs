using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    public class Attachment
    {

        public int Id { get; set; }
        public int MessageId { get; set; }
        public string FileName { get; set; }
        public byte[] Context { get; set; }

        public virtual Message Message { get; set; }

    }
}
