using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Hp { get; set; }
        public string State { get; set; }

        public Monster(int level, string name, int hp, int attak, string state)
        {
            Level = level;
            Name = name;
            Hp = hp;
            Attack = attak;
            State = state;
        }

        public void ShowMonsterStatus()
        {
            Console.WriteLine($"Lv. {Level} {Name} HP {Hp} {State}");
        }
    }
}
