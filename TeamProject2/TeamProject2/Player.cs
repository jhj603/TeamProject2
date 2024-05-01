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

        public void ShowStatus()
        {
            string Name = "조창일";
            string Job = "전사";
            int Level = 1;
            int Attack = 10;
            int Defense = 5;
            int Hp = 100;
            int Gold = 1500;

            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체  력 : {Hp}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }
}
