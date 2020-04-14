using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Repositories;
using System;
using SantaWorkshop.Models.Instruments;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Presents;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Workshops;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {

            if (dwarfType == "SleepyDwarf")
            {
                dwarfs.Add(new SleepyDwarf(dwarfName));

            }
            else if (dwarfType == "HappyDwarf")
            {
                dwarfs.Add(new HappyDwarf(dwarfName));

            }
            else
            {
                throw new InvalidOperationException("Invalid dwarf type.");
            }


            return $"Successfully added {dwarfType} named {dwarfName}.";

        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = dwarfs.FindByName(dwarfName);
            if (dwarf==null)
            {
                throw new InvalidOperationException("The dwarf you want to add an instrument to doesn't exist!");
            }
            dwarf.Instruments.Add(new Instrument(power));

            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";

        }

        public string AddPresent(string presentName, int energyRequired)
        {
            presents.Add(new Present(presentName, energyRequired));
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            var present = presents.FindByName(presentName);

            var bestDwarf = GetBestDwarf();
            if (bestDwarf.Energy<50)
            {
                throw new InvalidOperationException("There is no dwarf ready to start crafting!");
            }
            workshop.Craft(present, bestDwarf);

            if (bestDwarf.Energy<=0)
            {
                dwarfs.Remove(bestDwarf);
               
            }
            if (present.IsDone())
            {
                return $"Present {presentName} is done.";
            }
            else
            {
                return $"Present { presentName} is not done.";
            }


        }

        public string Report()
        {
            var sb = new StringBuilder();
            int countCraftedPresents = presents.Models.Where(p => p.IsDone()).Count();
            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");
               
            foreach (var dwarf  in dwarfs.Models)
            {
                var countInstruments = dwarf.Instruments.Where(i=>!i.IsBroken()).Count();
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {countInstruments} not broken left");

            }
            return sb.ToString().TrimEnd();

        }




        public IDwarf GetBestDwarf()
        {
            IDwarf bestDwarf = null;
            var energySum = 0;

            foreach (var dwarf in dwarfs.Models)
            {
                var currentSum = dwarf.Energy + dwarf.Instruments.Sum(i => i.Power);
                if (currentSum>energySum)
                {
                    energySum = currentSum;
                    bestDwarf = dwarf;
                }

            }
            return bestDwarf;

        }
    }
}