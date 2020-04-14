﻿using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private List<IMachine> machines;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public ICollection<IMachine> Machines => this.machines;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }


        public void AddMachine(IMachine machine)
        {
            if (machine==null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.Machines.Add(machine);


        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in this.Machines)
            {
                sb.AppendLine($"- {machine.Name}");
                sb.AppendLine($" *Type: {machine.GetType().Name}");
                sb.AppendLine($" *Health: {machine.HealthPoints}");
                sb.AppendLine($" *Attack: {machine.AttackPoints}");
                sb.AppendLine($" *Defense: {machine.DefensePoints}");
                sb.AppendLine($" *Targets: {machine.Targets}");
            }
            return sb.ToString().TrimEnd();



        }
    }
}
