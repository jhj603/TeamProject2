﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Player
    {
        // private으로 접근 제한해놨으므로
        // Player 클래스 외부에서 사용하려면 프로퍼티를 적용해야 함

        private int attack = 0;         // 공격력

        private int hp = 0;             // HP

        private int defense = 0;        // 방어력

        private int level = 0;          // 레벨

        private string name = null;     // 이름

        private string job = null;      // 직업

        private int gold = 0;           // 소지금


        public Player (int attack, int hp, int defense, int level, string name, string job, int gold)
        {
            this.attack = attack;
            this.hp = hp;
            this.defense = defense;
            this.level = level;
            this.name = name;
            this.job = job;
            this.gold = gold;
        }

        public void ShowStatus()
        {
            // 플레이어 필드를 사용해 문자열 생성 후 출력
            Console.WriteLine($"Lv. {0:D1}{level}");            
            Console.WriteLine($"{name} ( {job} )");
            Console.WriteLine($"공격력 : {attack}");
            Console.WriteLine($"방어력 : {defense}");
            Console.WriteLine($"체  력 : {hp}");
            Console.WriteLine($"Gold : {gold} G");      
        }

        public void PlayerAttack(Monster monster)
        {
            // monster의 hp에서 player의 attack을 뺌

            // monster의 hp가 0 이하라면
                // monster의 hp = 0
        }

        public void ShowDungeonStatus()
        {
            // 레벨, 이름, 직업으로 문자열 생성 후 출력
            // HP로 문자열 생성 후 출력
        }
    }
}
