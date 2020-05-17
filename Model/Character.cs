using System.Collections.Generic;
using System;
using dotnet_rpg.Model;
namespace dotnet_rpg.Model
{
        public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
     public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

        public User user{get;set;}
    }
}