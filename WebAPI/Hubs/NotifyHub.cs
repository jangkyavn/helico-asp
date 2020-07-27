using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    [Authorize]
    public class NotifyHub : Hub<INotifyHub>
    {
    }
}
