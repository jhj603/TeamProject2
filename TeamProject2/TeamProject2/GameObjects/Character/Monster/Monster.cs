using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum MonsterType
    {
        Minion,
        VoidInsect,
        SiegeMinion,
        MonsterTypeEnd
    }

    internal class Monster : BaseCharacter
    {
        public MonsterType MonType { get; private set; }

        public Monster(int level, MonsterType type, string name, float attack, int hp, int exp)
        {
            base.Initialize(level, name, attack, hp, 0, 0, exp);

            MonType = type;
        }

        public Monster(Monster monster)
        {
            base.Initialize(monster.Level, monster.Name, monster.Attack, monster.HP, 0, 0, monster.Exp);

            MonType = monster.MonType;
        }

        public override void PrintStatus()
        {
            Console.Write($"Lv.{Level} {Name}");

            if (CharacterState.Alive == CurrentState)
                Console.WriteLine($"    HP : {HP}");
            else if (CharacterState.Dead == CurrentState)
                Console.WriteLine($"    Dead");
        }
    }
}
