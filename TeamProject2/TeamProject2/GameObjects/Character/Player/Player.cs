using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject2;

namespace TeamProject2
{
    enum PlayerJob          // 플레이어 직업 종류
    {
        Warrior = 1,
        Magician,
        Archer
    }

    internal class Player : BaseCharacter
    {
        public PlayerJob Job { get; private set; }
        public int Defense { get; private set; }
        public int MaxHP { get; private set; }
        public int MaxMP { get; private set; }
        public int CurrentDungeon { get; private set; } = 1;
        public int CurrentSkillCount { get; private set; } = 0;

        // Player 필드 초기화 함수
        public bool Initialize(int level, string name, PlayerJob job, int attack, int defense, int hp, int gold, int mp)        // 레벨, 이름, 직업, 공격력, 방어력, hp, 소지금을 차례로 받아 초기화에 사용
        {
            base.Initialize(level, name, attack, hp, gold, mp);

            Job = job;                                              // 자식 클래스(Player)만 갖고 있는 필드 초기화
            Defense = defense;                                      // 자식 클래스(Player)만 갖고 있는 필드 초기화
            MaxHP = hp;
            MaxMP = mp;

            Skills = new List<Skill>();

            SkillManager skillManager = SkillManager.GetInstance();

            if (null == skillManager)
                return false;

            skillManager.GetSkills(Job, Skills);

            foreach (Skill skill in Skills)
            {
                if (skill.Level <= level)
                    ++CurrentSkillCount;
            }

            return true;
        }

        public void IncreaseDungeon()
        {
            ++CurrentDungeon;
        }

        public override void PrintStatus()
        {
            Console.WriteLine($"Lv. {Level}");
            Console.Write($"{Name} ( ");

            switch (Job)
            {
                case PlayerJob.Warrior:
                    Console.WriteLine("전사 )");
                    break;
                case PlayerJob.Magician:
                    Console.WriteLine("마법사 )");
                    break;
                case PlayerJob.Archer:
                    Console.WriteLine("궁수 )");
                    break;
            }

            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"H   P  : {HP}");
            Console.WriteLine($"M   P  : {MP}");
            Console.WriteLine($"Gold   : {Gold}\n");

            Console.WriteLine("[스킬]");

            PrintSkills();
        }

        public void PrintDungeonStatus()
        {
            Console.Write($"Lv.{Level} {Name} ( ");

            switch (Job)
            {
                case PlayerJob.Warrior:
                    Console.WriteLine("전사 )");
                    break;
                case PlayerJob.Magician:
                    Console.WriteLine("마법사 )");
                    break;
                case PlayerJob.Archer:
                    Console.WriteLine("궁수 )");
                    break;
            }

            Console.WriteLine($"HP {HP} / {MaxHP}");
            Console.WriteLine($"MP {MP} / {MaxMP}");
        }

        public void PrintSkills()
        {
            for (int i = 0; i < CurrentSkillCount; ++i)
            {
                Console.Write($"{i + 1}. ");
                Skills[i].PrintSkill();
            }
        }

        public bool CanUseSkill(int skillIndex)
        {
            return MP > Skills[skillIndex].Cost;
        }
    }
}
