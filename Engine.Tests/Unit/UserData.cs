using Engine.Users;

namespace Engine.Tests.Unit
{
    public static class UserData
    {
        public static EventHub eventHub = new TestEventHub();
        public static Party party1 = new Party(1, eventHub);
        public static Party party2 = new Party(2, eventHub);      
    }
}
