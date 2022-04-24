using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.RabbitMq.Bus.Events;

namespace TestApplication.RabbitMq.Bus.EventQueue
{
    public class EmailEventQueue : Event
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public EmailEventQueue(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
