using Engine;
using Engine.Users;
using Microsoft.AspNetCore.SignalR.Client;

//var myMachine = ChatRepository.parties.Where(x => x.Id == 1).FirstOrDefault();
//Thread.Sleep(15000);
//myMachine.rooms.FirstOrDefault()._messages.ForEach(x=>Console.WriteLine(x.content));
HubConnection connection;
connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:7106/ChatHub")
               .Build();
connection.On<string>("ReceiveMessage", ( message) =>
{
   Console.WriteLine(message);
});
try
{
    await connection.StartAsync();
    Console.WriteLine("Connection started");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
while (true) { }