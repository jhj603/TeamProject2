﻿using System;
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
        public float Attack { get; protected set; }         // 공격력
        public int HP { get; protected set; }             // HP
        public int Gold { get; protected set; }           // 소지금

        public int MP { get; protected set; }

        public int Exp { get; protected set; }

        public CharacterState CurrentState { get; protected set; }

        public int CurrentDamage { get; protected set; }

        public bool IsCritical { get; protected set; } = false;

        public List<Skill> Skills { get; protected set; } = null;

        protected Random? rand = null;

        int percent = 0;
        int error = 0;

        public abstract void PrintStatus();

        public void Initialize(int level, string name, float attack, int hp, int gold, int mp, int exp)        // 위 필드들을 초기화하는 함수
        {
            Level = level;
            Name = name;
            Attack = attack;
            HP = hp;
            Gold = gold;
            MP = mp;
            Exp = exp;

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
                CurrentDamage = rand.Next((int)(Attack - error), (int)(Attack + error + 1));
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

        public List<int> SkillAttack(int skillChoice, Monster monster)
        {
            List<int> Damages = Skills[skillChoice].GetSkillDamages(Attack);

            foreach (int damage in Damages)
            {
                monster.Hit(damage);

                if (CharacterState.Dead == monster.CurrentState)
                    break;
            }

            return Damages;
        }
    }
}