using Engine.Users;

namespace Engine.Tests.Unit
{
    public static class UserData
    {
        public static EventHub eventHub =new TestEventHub();
        public static User user1 = new User(1, eventHub);
        public static User user2 = new User(2, eventHub);
       
    }
}
