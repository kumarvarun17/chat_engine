using Engine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tests.Unit
{
    internal static class ChatRepository
    {
      internal static List<ChatRecord> records = [];

    }

    internal record ChatRecord (Guid? Id, ChatMessage Message, Party Sender, Party Receiver);
}
