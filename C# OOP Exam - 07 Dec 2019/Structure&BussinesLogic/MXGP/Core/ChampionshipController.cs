using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motorRepository;
        private RiderRepository riderRepository;
        private RaceRepository raceRepository;
        

        public ChampionshipController()
        {
            this.motorRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
           
        }

        public string CreateRider(string riderName)
        {
            if (riderRepository.Models.Any(r => r.Name == riderName))
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            else
            {
                var rider = new Rider(riderName);
                riderRepository.Models.Add(rider);
                return $"Rider {riderName} is created.";
            }
        }
        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            string messege = string.Empty;
            if (type=="Power")
            {
                var motorcycle = new PowerMotorcycle(model, horsePower);
                if (motorRepository.Models.Contains(motorcycle))
                {
                    throw new ArgumentException($"Motorcycle {model} is already created.");
                }
                motorRepository.Add(motorcycle);
                messege= $"PowerMotorcycle {model} is created.";
            }
            else if (type=="Speed")
            {
                var motorcycle = new SpeedMotorcycle(model, horsePower);
                if (motorRepository.Models.Contains(motorcycle))
                {
                    throw new ArgumentException($"Motorcycle {model} is already created.");
                }
                motorRepository.Add(motorcycle);
                messege= $"SpeedMotorcycle {model} is created.";
            }
            return messege;


        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.Models.FirstOrDefault(x=>x.Name==riderName);
            var motorcycle = motorRepository.Models.FirstOrDefault(r => r.Model == motorcycleModel);
           
           if (motorcycle==null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
           else if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else
            {
                rider.AddMotorcycle(motorcycle);
                return $"Rider {riderName} received motorcycle {motorcycleModel}.";
            }
           
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.Models.FirstOrDefault(r => r.Name == raceName);
            var rider = riderRepository.Models.FirstOrDefault(x => x.Name == riderName);
            if (race==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
           else if (rider==null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else
            {
                race.AddRider(rider);
                return $"Rider {riderName} added in {raceName} race.";
            }
        }


        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.Models.FirstOrDefault(r => r.Name == name);
            if (race!=null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            else
            {
                raceRepository.Models.Add(new Race(name, laps));
                return $"Race {name} is created.";
            }
        }


        public string StartRace(string raceName)
        {

            var race = raceRepository.Models.FirstOrDefault(r => r.Name == raceName);
            if (race==null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
           else if (race.Riders.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
          
           var winners = riderRepository.Models.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).ToList();
           
           var firstplace = winners[0].Name;
           var secondPlace = winners[1].Name;
           var thirdPlace = winners[2].Name;
           raceRepository.Remove(race);
           
            var sb = new StringBuilder();
           sb.AppendLine($"Rider {firstplace} wins {raceName} race.");
           sb.AppendLine($"Rider {secondPlace} is second in {raceName} race.");
           sb.AppendLine($"Rider {thirdPlace} is third in {raceName} race.");
           
           return sb.ToString().TrimEnd();

            
        }
    }
}
