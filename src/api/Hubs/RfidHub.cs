using Microsoft.AspNetCore.SignalR;

public class RfidHub:Hub
{
   public async Task SendDashboard(string uid)
    {
        await Clients.Group("Dashboard").SendAsync("ReceiveUid",uid);
    }
    public async Task SendClient(CardDto cardDto)
    {
        await Clients.Group("Client").SendAsync("ReceiveCard",cardDto);
    }
    public async Task UnAssignedCard(string uid)
    {
        await Clients.Group("Client").SendAsync("UnAssignedCard",uid);
    }
    public override async  Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var type = httpContext?.Request.Query["type"].ToString();
        if(type == "dashboard")
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Dashboard");
        }
        else
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Client");
        }
        await base.OnConnectedAsync();
    }
}