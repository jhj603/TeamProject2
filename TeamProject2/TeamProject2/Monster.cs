﻿using System;
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

        public Monster(int level, string name, int hp, int attak)
        {
            Level = level;
            Name = name;
            Hp = hp;
            Attack = attak;
        }
    }
}
