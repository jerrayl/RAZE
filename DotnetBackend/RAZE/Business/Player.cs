using System;
using RAZE.Entities;
using RAZE.Repositories;
using RAZE.Models;

namespace RAZE.Business
{
    public class Player : IPlayer
    {
        private IDatabaseRepository<PlayerSession> _playerSessions;
        private IDatabaseRepository<Account> _accounts;
        private IDatabaseRepository<Request> _requests;

        public Player(
            IDatabaseRepository<PlayerSession> playerSessions,
            IDatabaseRepository<Account> accounts,
            IDatabaseRepository<Request> request)
        {
            _playerSessions = playerSessions;
            _accounts = accounts;
            _requests = request;
        }

        public void Login(string email, string connectionId)
        {
            var userAccount = _accounts.ReadOne(account => account.Email.Equals(email));

            if (userAccount is null)
            {
                userAccount = new Account() { Email = email };
                _accounts.Create(userAccount);
            }

            var activeSession = _playerSessions.ReadOne(session => session.AccountId.Equals(userAccount.Id) && session.Token.Equals(connectionId) && session.ExpiresAt > DateTime.UtcNow);

            if (activeSession is null){
                activeSession = new PlayerSession() {
                    AccountId = userAccount.Id, 
                    ExpiresAt = DateTime.UtcNow.AddHours(2), 
                    Token = connectionId
                };
            }
        }

        public RequestModel SendRequest(string connectionId, string email, out string errorMessage){
            errorMessage = null;

            var senderSession = _playerSessions.ReadOne(session => session.Token.Equals(connectionId) && session.ExpiresAt > DateTime.UtcNow, senderSession => senderSession.Account);

            if (senderSession is null){
                errorMessage = "Player is not logged in";
                return null;
            }

            var receiverAccount = _accounts.ReadOne(account => account.Email.Equals(email));

            if (receiverAccount is null){
                errorMessage = "Email could not be found";
                return null;
            }

            var receiverSession = _playerSessions.ReadOne(session => session.AccountId.Equals(receiverAccount.Id) && session.ExpiresAt > DateTime.UtcNow);

            if (receiverSession is null){
                errorMessage = "Receiver is not logged in";
                return null;
            }

            var request = new Request() {
                SenderId = senderSession.AccountId, 
                ReceiverId = receiverAccount.Id, 
                ExpiresAt = DateTime.UtcNow.AddHours(1), 
                Identifier = Guid.NewGuid().ToString().ToLower()
            };

            _requests.Create(request);

            return new RequestModel(){
                Sender = senderSession.Account.Email, 
                ReceiverConnectionId = receiverSession.Token, 
                ExpiresAt = request.ExpiresAt, 
                RequestIdentifier = request.Identifier
            };
        }

        public bool AcceptRequest(string requestIdentifier){
            return true;
        }
    }
}
