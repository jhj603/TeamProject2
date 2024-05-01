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
        public int CurrentDungeon { get; private set; } = 1;

        // Player 필드 초기화 함수
        public void Initialize(int level, string name, PlayerJob job, int attack, int defense, int hp, int gold)        // 레벨, 이름, 직업, 공격력, 방어력, hp, 소지금을 차례로 받아 초기화에 사용
        {
            base.Initialize(level, name, attack, hp, gold);         // 부모 클래스(BaseCharacter)의 Initialize() 함수를 불러 필드 초기화

            Job = job;                                              // 자식 클래스(Player)만 갖고 있는 필드 초기화
            Defense = defense;                                      // 자식 클래스(Player)만 갖고 있는 필드 초기화
            MaxHP = hp;
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
            Console.WriteLine($"체  력 : {HP}");
            Console.WriteLine($"Gold   : {Gold}");
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
        }
    }
}

// 플레이어 객체 생성법
//Player newPlayer = new Player();

//newPlayer.Initialize(1, "이름", "직업", 8, 10, 100, 1500);
//채우고 싶은 원하는 값