using RAZE.Models;

namespace RAZE.Business
{
    public interface IPlayer
    {
        void Login(string email, string connectionId);
        RequestModel SendRequest(string connectionId, string email, out string errorMessage);
        bool AcceptRequest(string requestIdentifier);
    }
}
