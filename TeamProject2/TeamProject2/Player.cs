using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Player
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Player()
        {
            Name = "조창일";
            Job = "전사";
            Level = 1;
            Attack = 10;
            Defense = 5;
            Hp = 100;
            Gold = 1500;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체  력 : {Hp}");
            Console.WriteLine($"Gold : {Gold}");
        }

        public void ShowDunGeonStatus()
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{Level} {Name} ({Job})");
            Console.WriteLine($"HP {Hp}/{Hp}");
        }

        public void PlayerAttack()
        {
            Console.WriteLine($"{Name} 의 공격!");
        }
    }
}
