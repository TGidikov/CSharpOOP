using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private Mission mission;
        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type=="Biologist")
            {
                astronautRepository.Add(new Biologist(astronautName));
            }
            else if (type == "Geodesist")
            {
                astronautRepository.Add(new Geodesist(astronautName));
            }
            else if (type=="Meteorologist")
            {
                astronautRepository.Add(new Meteorologist(astronautName));
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            return $"Successfully added {type}: {astronautName}!";


        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            planet.AddItems(items);
            planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }
        public string RetireAstronaut(string astronautName)
        {
            var retiredAstronaut = astronautRepository.Models.FirstOrDefault(a=>a.Name==astronautName);
            if (retiredAstronaut==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronautRepository.Remove(retiredAstronaut);
            return $"Astronaut {astronautName} was retired!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsWihOxygen = new List<IAstronaut>();
            foreach (var astronault in astronautRepository.Models.Where(a=>a.Oxygen>60))
            {
                astronautsWihOxygen.Add(astronault);
            }
            if (astronautsWihOxygen.Count==0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            var planet = planetRepository.FindByName(planetName);
            

            mission.Explore(planet, astronautsWihOxygen);
            var deadAstronauts = astronautsWihOxygen.Where(a => a.Oxygen>0).Count();

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";

        }

        public string Report()
        {
            var exploredPlanets = planetRepository.Models.Where(p => p.Items.Count == 0);

            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: { astronaut.Oxygen}");
                sb.AppendLine("Bag items: ");
                foreach (var item in astronaut.Bag.Items)
                {
                    sb.Append($"{item}");
                }
                
            }

            return sb.ToString().TrimEnd();

        }

    }
}
