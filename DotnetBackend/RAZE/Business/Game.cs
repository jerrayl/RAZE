using System;
using System.Linq;
using System.Collections.Generic;
using RAZE.Entities;
using RAZE.Repositories;
using RAZE.Models;

namespace RAZE.Business
{
    public class Game : IGame
    {
        private IDatabaseRepository<GameRoom> _gameRooms;
        private IDatabaseRepository<PlayerSession> _playerSessions;
        private IDatabaseRepository<PlayerBonus> _playerBonuses;
        private IDatabaseRepository<PlayerResource> _playerResources;
        private IDatabaseRepository<PlayerProduction> _playerProduction;
        private IDatabaseRepository<PlayerBuilding> _playerBuildings;
        private IDatabaseRepository<StatusType> _statusTypes;
        private IDatabaseRepository<Building> _buildings;
        private IDatabaseRepository<BonusType> _bonusTypes;
        private IDatabaseRepository<Element> _elements;
        private Dictionary<int, string> _buildingCache = null;
        private Dictionary<int, string> _bonusTypeCache = null;
        private Dictionary<int, string> _elementCache = null;
        private Dictionary<string, int> _statusTypeCache = null;
        private readonly List<string> BASE_ELEMENTS = new List<string> { Constants.FIRE, Constants.WATER, Constants.EARTH, Constants.AIR };

        public Game(
            IDatabaseRepository<GameRoom> gameRooms,
            IDatabaseRepository<PlayerSession> playerSessions,
            IDatabaseRepository<PlayerBonus> playerBonuses,
            IDatabaseRepository<PlayerResource> playerResources,
            IDatabaseRepository<PlayerProduction> playerProduction,
            IDatabaseRepository<PlayerBuilding> playerBuildings,
            IDatabaseRepository<StatusType> statusType,
            IDatabaseRepository<Building> buildings,
            IDatabaseRepository<BonusType> bonusTypes,
            IDatabaseRepository<Element> elements)
        {
            _gameRooms = gameRooms;
            _playerSessions = playerSessions;
            _playerBonuses = playerBonuses;
            _playerResources = playerResources;
            _playerProduction = playerProduction;
            _playerBuildings = playerBuildings;
            _statusTypes = statusType;
            _buildings = buildings;
            _bonusTypes = bonusTypes;
            _buildings = buildings;
            _elements = elements;
        }

        private void CreateCache()
        {
            if (_buildingCache is null)
                _buildingCache = _buildings.Read().ToDictionary(building => building.Id, building => building.Identifier);
            if (_bonusTypeCache is null)
                _bonusTypeCache = _bonusTypes.Read().ToDictionary(bonusType => bonusType.Id, bonusType => bonusType.Name);
            if (_elementCache is null)
                _elementCache = _elements.Read().ToDictionary(element => element.Id, element => element.Name);
            if (_statusTypeCache is null)
                _statusTypeCache = _statusTypes.Read().ToDictionary(statusType => statusType.Name, statusType => statusType.Id);
        }

        public GameStateModel GetGameState(string gameRoomIdentifier)
        {
            CreateCache();
            var gameRoom = _gameRooms.ReadOne(gameRoom => gameRoom.Identifier == gameRoomIdentifier, gameRoom => gameRoom.StatusType);
            var gameState = new GameStateModel()
            {
                Status = gameRoom.StatusType.Name,
                Players = new List<PlayerModel>()
            };

            var players = _playerSessions.Read(player => player.GameRoomId.Equals(gameRoom.Id),
                player => player.PlayerBonuses,
                player => player.PlayerResources,
                player => player.PlayerProductions,
                player => player.PlayerBuildings,
                player => player.Account);

            gameState.CurrentPlayer = players.Where(player => player.IsCurrentPlayer).Single().Account.Email;

            foreach (var player in players)
            {
                var playerModel = new PlayerModel() { Email = player.Account.Email };
                playerModel.PlayerBonuses = player.PlayerBonuses.Select(bonus => new PlayerBonusModel() { BonusType = _bonusTypeCache[bonus.BonusTypeId], Number = bonus.Number }).ToList();
                playerModel.PlayerResources = player.PlayerResources.Select(resource => new PlayerResourceModel() { Element = _elementCache[resource.ElementId], Number = resource.Number }).ToList();
                playerModel.PlayerProduction = player.PlayerProductions.Select(production => new PlayerResourceModel() { Element = _elementCache[production.ElementId], Number = production.Number }).ToList();
                playerModel.PlayerBuildings = player.PlayerBuildings.Select(building => new PlayerBuildingModel() { BoardSpace = building.BoardSpace, BuildingIdentifier = _buildingCache[building.BuildingId] }).ToList();
                gameState.Players.Add(playerModel);
            }

            return gameState;
        }

        public void InitializeGame(string gameRoomIdentifier)
        {
            CreateCache();
            var gameRoom = _gameRooms.ReadOne(gameRoom => gameRoom.Identifier == gameRoomIdentifier);
            var players = _playerSessions.Read(player => player.GameRoomId.Equals(gameRoom.Id));

            gameRoom.StatusTypeId = _statusTypeCache[Constants.BUILD];
            _gameRooms.Update(gameRoom);

            var randomPlayer = players.OrderBy(_ => new Random().NextDouble()).First();
            randomPlayer.IsCurrentPlayer = true;
            _playerSessions.Update(randomPlayer);

            foreach (var player in players)
            {
                foreach (var bonusTypeId in _bonusTypeCache.Keys)
                {
                    _playerBonuses.Add(new PlayerBonus() { PlayerId = player.Id, BonusTypeId = bonusTypeId, Number = 0 });
                }
                foreach (var elementId in _elementCache.Keys)
                {
                    _playerProduction.Add(new PlayerProduction() { PlayerId = player.Id, ElementId = elementId, Number = 0 });
                }
                foreach (var elementId in _elementCache.Keys)
                {
                    _playerResources.Add(new PlayerResource() { PlayerId = player.Id, ElementId = elementId, Number = BASE_ELEMENTS.Contains(_elementCache[elementId]) ? 20 : 0 });
                }
            }
        }

        public string PlaceBuilding(string connectionId, string buildingIdentifier, int boardSpace, out string errorMessage){
            errorMessage =  null;
            // ensure player exists
            // ensure player is in active game session
            // ensure game is in build state
            // ensure it it currently player's turn
            // ensure no other buildings in spot
            // ensure player has resources to place building

            // create playerbuilding
            // update playerresources
            // update playerproduction
            // update playerbonuses

            // switch to other player's turn

            return "";
        }
    }
}
