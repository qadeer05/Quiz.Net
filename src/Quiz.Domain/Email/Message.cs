using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    public class Message
    {

        public Message()
        {
            Attachments = new List<Attachment>();
        }

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public DateTime? SentOn { get; set; }
        public int RetryCount { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

    }
}
