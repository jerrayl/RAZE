using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RAZE.Entities;
using RAZE.Models;
using RAZE.Repositories;
namespace RAZE.Business
{
    public class Info : IInfo
    {
        private IDatabaseRepository<Building> _buildings;
        private IDatabaseRepository<BuildingCost> _buildingCosts;
        private IDatabaseRepository<Troop> _troops;
        private IDatabaseRepository<TroopCost> _troopCosts;
        private IDatabaseRepository<Element> _elements;

        public Info(
            IDatabaseRepository<Building> buildings,
            IDatabaseRepository<BuildingCost> buildingCosts,
            IDatabaseRepository<Troop> troops,
            IDatabaseRepository<TroopCost> troopCosts,
            IDatabaseRepository<Element> elements)
        {
            _buildings = buildings;
            _buildingCosts = buildingCosts;
            _troops = troops;
            _elements = elements;
        }

        public List<BuildingModel> GetBuildings()
        {

var elements = _elements.Read(element => true).ToDictionary(element => element.Id, element => element.Name);

           var buildings = _buildings.Read(building => true, building => building.BuildingCosts, building => building.Element);
            return 
                buildings
                .Select(building => new BuildingModel() { 
                    
                    Name = building.Name,
        Identifier = building.Identifier,
        Image = building.Image,
        Tier = building.Tier,
        Element = building.Element.Name,
        Production = building.Production,
        Health = building.Health,
        Effect = building.Effect,
        Cost = building.BuildingCosts.Select(cost => new CostModel(){
            Element = elements[cost.ElementId],
            Number = cost.Number

        }).ToList() })
                .ToList();
        }

        public List<TroopModel> GetTroops()
        {
            return new List<TroopModel>();
        }
    }
}
