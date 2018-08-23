using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technoshop.Web.Helpers.Message
{
    [Serializable]
    public class MessageModel
    {
        public MessageType Type { get; set; }

        public string Message { get; set; }
    }
}
