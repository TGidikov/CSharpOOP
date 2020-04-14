namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;


        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();

        }

        public string HirePilot(string name)
        {
            if (pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                var pilot = new Pilot(name);
                pilots.Add(pilot);
                return $"Pilot {name} hired";
            }
        }
        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == pilotReporting);
            return pilot.Report();
        }
        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tankExist = machines.FirstOrDefault(m => m.Name == name);
            if (tankExist != null)
            {
                return $"Machine {name} is manufactured already";
            }
            else;
            {
                machines.Add(new Tank(name, attackPoints, defensePoints));
                return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
            }              
        }
        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var tankExist = machines.FirstOrDefault(m => m.Name == name);
            if (tankExist != null)
            {
                return $"Machine {name} is manufactured already";
            }
            else
            {
                machines.Add(new Fighter(name, attackPoints, defensePoints));
                return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: ON";
            }

        }
        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var machine = (IFighter)machines.FirstOrDefault(m => m.Name == fighterName);
            if (machine==null)
            {
                return $"Machine {fighterName} could not be found";
            }
            machine.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";

        }
        public string ToggleTankDefenseMode(string tankName)
        {
            var tankExist = (ITank)machines.FirstOrDefault(m => m.Name == tankName);
            if (tankExist == null)
            {
                return $"Machine {tankName} could not be found";
            }
            tankExist.ToggleDefenseMode();
            return $"Tank {tankName} toggled defense mode";
          
        }


        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (pilot==null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }           
            else if (machine==null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            else if (machine.Pilot!=null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }




        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(m => m.Name ==defendingMachineName);
            if (attackingMachine==null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            else if (defendingMachineName==null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            if (attackingMachine.HealthPoints<=0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (defendingMachine.HealthPoints<=0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                attackingMachine.Attack(defendingMachine);
                return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints}";
            }


        }




    }
}