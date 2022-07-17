using RAZE.Models;
using RAZE.Business;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RAZE.SignalR
{
    public class SignalRHub : Hub
    {
        private readonly IPlayer _player;
        public SignalRHub(IPlayer player){
            _player = player;
        }   

        public async Task<string> SendRequest(EmailModel model)
        {
            var request = _player.SendRequest(Context.ConnectionId, model.Email, out string errorMessage);
            if (request != null)
                await Clients.Client(request.ReceiverConnectionId).SendAsync("Request", request);
            return errorMessage;
        }

        public string Login(EmailModel model)
        {
            _player.Login(model.Email, Context.ConnectionId);
            return "Logged in";
        }
    }
}
