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
        SiegeMinion
    }

    internal class Monster : BaseCharacter
    {
        MonsterType monsterType;

        public Monster(int level, MonsterType type, string name, int attack, int hp)
        {
            base.Initialize(level, name, attack, hp, 0);

            monsterType = type;
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
