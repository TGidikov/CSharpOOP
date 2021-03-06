﻿using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        private bool isAlive = true;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                this.username = value;
            }

        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player health cannot be below or equal to 0.");
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {

                    throw new ArgumentException("Player armor cannot be below 0.");
                }
                this.armor = value;
            }
        }
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            private set
            {
                if (this.Health == 0)
                {
                    this.isAlive = false;
                }

            }

        }

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Gun cannot be null.");
                }
                this.gun = value;
            }

        }


        public void TakeDamage(int points)
        {
            if (IsAlive)
            {
                if (this.Armor > 0)
                {
                    this.Armor -= points;
                }
                else
                {
                    this.Health -= points;
                }

            }
        }


    }
}
