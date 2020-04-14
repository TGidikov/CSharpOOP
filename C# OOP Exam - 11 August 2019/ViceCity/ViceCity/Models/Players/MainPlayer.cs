﻿namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int INITIAL_LIFE_POINTS = 100;
        private const string INITIAL_NAME = "Tommy Vercetti";
        public MainPlayer() : base(INITIAL_NAME, INITIAL_LIFE_POINTS)
        {
        }
    }
}
