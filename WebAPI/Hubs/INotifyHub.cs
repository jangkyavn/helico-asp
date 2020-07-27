using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    public interface INotifyHub
    {
        Task ReceiveMessage(string message);
    }
}
