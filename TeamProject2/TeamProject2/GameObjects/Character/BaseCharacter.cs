using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class BaseCharacter
    {
        public int Level { get; private set; }          // 레벨
        public string? Name { get; private set; }       // 이름
        public int Attack { get; private set; }         // 공격력
        public int HP { get; private set; }             // HP
        public int Gold { get; private set; }           // 소지금

        public void Initialize(int level, string name, int attack, int hp, int gold)        // 위 필드들을 초기화하는 함수
        {
            Level = level;
            Name = name;
            Attack = attack;
            HP = hp;
            Gold = gold;
        }
    }
}
