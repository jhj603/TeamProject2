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
        public int Level { get; protected set; }          // 레벨
        public string? Name { get; protected set; } = null;       // 이름
        public int Attack { get; protected set; }         // 공격력
        public int HP { get; protected set; }             // HP
        public int Gold { get; protected set; }           // 소지금

        public CharacterState CurrentState { get; protected set; }

        public int CurrentDamage { get; protected set; }

        public bool IsCritical { get; protected set; } = false;

        protected Random? rand = null;

        int percent = 0;
        int error = 0;

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
            IsCritical = false;

            percent = rand.Next(0, 100);

            if (15 > percent)
            {
                IsCritical = true;

                CurrentDamage = (int)(Attack * 1.6f);
            }
            else
            {
                error = (int)Math.Ceiling(Attack * 0.1f);
                CurrentDamage = rand.Next(Attack - error, Attack + error);
            }

            target.Hit(CurrentDamage);
        }

        public void Hit(int attack)
        {
            HP -= attack;

            if (0 >= HP)
            {
                CurrentState = CharacterState.Dead;
                HP = 0;
            }
        }

        public bool IsDodge()
        {
            percent = rand.Next(0, 100);

            if (10 > percent)
                return true;

            return false;
        }
    }
}
