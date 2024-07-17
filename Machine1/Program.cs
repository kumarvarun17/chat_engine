using Engine;
using Engine.Users;
using Microsoft.AspNetCore.SignalR.Client;

//var myMachine = ChatRepository.parties[0];

//myMachine.Send(2, new ChatMessage("Hi", DateTime.Now));
HubConnection connection;
connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:7106/ChatHub")
               .Build();
try
{
    await connection.StartAsync();
    Console.WriteLine("Connection started");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
while(true)
{
    string message=Console.ReadLine();
    try
    {
        await connection.InvokeAsync("SendMessage", message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
