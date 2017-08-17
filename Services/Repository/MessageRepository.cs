using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repository
{
    public class MessageRepository: IMessageRepository
    {
        public string GetMessage()
        {
            return "Message Repository";
        }
    }
}
