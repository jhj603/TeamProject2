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

        public void ShowStatus()
        {
            // 무한 반복

                // "캐릭터의 정보가 표시됩니다." 까지 문자열 출력

                // 플레이어 필드를 사용해 문자열 생성 후 출력

                // 입력

                    // 0 입력

                        // ShowStatus() 함수 나가기

                    // 0 이외 정수 입력
                        
                        // "잘못된 입력입니다." 출력
                
                // 문자 입력

                    // "잘못된 입력입니다." 출력
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