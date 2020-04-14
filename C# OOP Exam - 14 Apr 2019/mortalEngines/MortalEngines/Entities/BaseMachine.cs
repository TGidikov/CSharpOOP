using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private List<string> targets;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

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
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return pilot;
            }
            set
            {
                if (pilot == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");

                }
                this.Pilot = pilot;
            }
        }

        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public double HealthPoints { get; set;}
        public IList<string> Targets => this.targets;

        public  void Attack(IMachine target)
        {
            if (target==null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            else
            {
                var attackPower = this.AttackPoints - target.DefensePoints;
                if (target.HealthPoints - attackPower>=0)
                {
                    target.HealthPoints -= attackPower;
                }
                else
                {
                    target.HealthPoints = 0;
                }
                this.Targets.Add(target.Name);
            }
        }

        
        public virtual string ToString()
        {
            var sb = new StringBuilder();
           
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.AppendLine($" *Targets: {(this.Targets.Any() ? string.Join(", ", this.Targets) : "none")}");
            return sb.ToString();
           
        }
    }
}
