using Engine.Tests.Unit;
using Engine.Users;

var myMachine = TestEventHub.GetInstance().Party(1);

myMachine.Send(2, new ChatMessage("Hi", DateTime.Now));