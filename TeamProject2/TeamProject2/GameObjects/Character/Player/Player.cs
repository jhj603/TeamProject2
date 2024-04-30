﻿using System;
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
        internal static object player;

        public PlayerJob Job { get; private set; }
        public int Defense { get; private set; }

        // Player 필드 초기화 함수
        public void Initialize(int level, string name, PlayerJob job, int attack, int defense, int hp, int gold)        // 레벨, 이름, 직업, 공격력, 방어력, hp, 소지금을 차례로 받아 초기화에 사용
        {
            base.Initialize(level, name, attack, hp, gold);         // 부모 클래스(BaseCharacter)의 Initialize() 함수를 불러 필드 초기화

            Job = job;                                              // 자식 클래스(Player)만 갖고 있는 필드 초기화
            Defense = defense;                                      // 자식 클래스(Player)만 갖고 있는 필드 초기화
        }
        
        // 플레이어 상태 보기 - 손두혁
        public void PrintStatus()
        {
            string nameinput = Name;

            PlayerJob inputJob = Job;

            Console.WriteLine($"Lv.{Level} {nameinput} ({inputJob})");
            Console.WriteLine($"HP {HP}/{HP}");
        }

        public void PlayerName()
        {
            string nameinput = Name;

            Console.WriteLine($"{nameinput} 의 공격");
        }
    }
}

// 플레이어 객체 생성법
//Player newPlayer = new Player();

//newPlayer.Initialize(1, "이름", "직업", 8, 10, 100, 1500);
//채우고 싶은 원하는 값