using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum CharacterState
    {
        Alive,
        Dead
    }

    internal abstract class BaseCharacter
    {
        public int Level { get; set; }          // 레벨
        public string? Name { get; set; }       // 이름
        public int Attack { get; set; }         // 공격력
        public int HP { get; set; }             // HP
        public int Gold { get; set; }           // 소지금

        public CharacterState CurrentState { get; private set; }

        public int CurrentDamage { get; private set; }

        Random? rand;

        public abstract void PrintStatus();

        public void Initialize(int level, string name, int attack, int hp, int gold)        // 위 필드들을 초기화하는 함수
        {
            Level = level;
            Name = name;
            Attack = attack;
            HP = hp;
            Gold = gold;

            CurrentState = CharacterState.Alive;

            rand = new Random();
        }

        public void AttackTarget(BaseCharacter target)
        {
            int error = (int)Math.Ceiling(Attack * 0.1f);
            CurrentDamage = rand.Next(Attack - error, Attack + error);

            target.HP -= CurrentDamage;

            if (0 >= target.HP)
            {
                target.CurrentState = CharacterState.Dead;
                target.HP = 0;
            }   
        }
    }
}
