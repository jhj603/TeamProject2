using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class BattleScene
    {
        Player status = null;               // 플레이어 객체
        List<Monster> monsters = null;      // 몬스터 객체들을 모아놓는 리스트

        int startHP = 0;                    // 배틀 시작 시 플레이어의 hp

        public bool MonsterSpawn()
        {
            // 몬스터 객체들을 모아놓는 리스트 monsters 객체 생성
            monsters = new List<Monster>();
            // 1 ~ 4 까지의 랜덤한 수 생성
            Random random = new Random();
            int randomCount = random.Next(1, 5);
            // 랜덤한 수만큼 반복
            for (int i = 0; i < randomCount; i++)
            {
                // 0 ~ 2 까지의 랜덤한 수 생성
                int randomType = random.Next(3);
                // 랜덤한 수가 0이면
                Monster monster;
                if (randomType == 0)
                {
                    // 미니언 몬스터 생성
                     monster = new Monster(2, "미니언", 15, 5);
                }
                // 랜덤한 수가 0이 아니고 1이면
                else if (randomType == 1)
                {
                    // 공허충 몬스터 생성
                    monster = new Monster(3, "공허충", 10, 9);
                }
                // 랜덤한 수가 0도 아니고 1도 아니면
                else
                {
                    // 대포 미니언 생성
                    monster = new Monster(5, "대포미니언", 25, 8);
                }
                // 만든 몬스터가 null이면
                if (monsters == null)
                {
                    // false 반환
                    return false;
                }
                // monsters 리스트에 생성한 Monster 객체 추가
                monsters.Add(monster);
            }
            return true;        // 몬스터 객체들을 생성한 뒤, 리스트에 추가한 작업이 끝나면 true 반환
        }

        bool MonsterHit(Monster monster)
        {
            // 변수를 만들어서 현재 monster의 HP 저장

            // Player.PlayerAttack(monster) 수행

            // 무한 반복

                // "Battle!!" 출력

                // 몬스터의 레벨, 이름, 플레이어의 데미지로 문자열 생성 후 출력

                // 입력

                    // 0. 입력

                        // true 반환

                    // 0 제외 숫자 입력
                          
                        // "잘못된 입력입니다." 출력
                
                // 문자 입력
                    
                    // "잘못된 입력입니다." 출력

            return false;
        }

        bool PlayerHit(Monster monster)
        {
            // 변수를 만들어서 현재 player의 HP 저장

            // Monster.MonsterAttack(player) 수행

            // 무한 반복

                // "Battle!!" 출력

                // 플레이어의 이름, 몬스터의 데미지로 문자열 생성 후 출력

                // 입력

                    // 0. 입력

                        // true 반환

                    // 0 제외 숫자 입력

                        // "잘못된 입력입니다." 출력

                // 문자 입력

                    // "잘못된 입력입니다." 출력

            return false;
        }        

        void PlayerVictory()
        {
            // 무한 반복

                // "Victory" 까지 문자열 출력

                // monsters의 크기로 "던전에서 몬스터 ~마리를 잡았습니다." 문자열 생성 후 출력

                // player의 레벨, 이름 으로 문자열 생성 후 출력
                // starthHp와 player의 hp로 문자열 생성 후 출력

                // 나머지 문자열 출력

                // 입력
                
                    // 0. 입력

                        // PlayerVictory() 함수 나가기

                    // 0 제외 숫자 입력

                        // "잘못된 입력입니다." 출력

                // 문자 입력

                    // "잘못된 입력입니다." 출력
        }

        void PlayerLose()
        {
            // 무한 반복

                // "You Lose" 까지 문자열 출력

                // player의 레벨, 이름 으로 문자열 생성 후 출력
                // starthHp와 player의 hp로 문자열 생성 후 출력

                // 나머지 문자열 출력

                // 입력

                    // 0. 입력

                        // PlayerLose() 함수 나가기

                    // 0 제외 숫자 입력

                        // "잘못된 입력입니다." 출력

                // 문자 입력

                    // "잘못된 입력입니다." 출력
        }

        public void ShowBattle()
        {
            // startHP에 현재 플레이어의 hp 저장
            int startHP = status.HP;

            // 무한 반복
            while (true)
            { 

                // "Battle!!" 문자열 출력
                Console.WriteLine("Battle!");


                // monsters의 크기만큼 반복
                for (int i = 0; i < monsters.Count; i++)
                {
                    // Monster.ShowMonsterStatus() 호출
                    monsters[i].ShowMonsterStatus();
                }

                // "[내정보]" 출력
                Console.WriteLine("[내정보]");

                // Player.ShowDungeonStatus() 호출
                status.ShowDungeonStatus();


                // 나머지 문자열 출력
                Console.WriteLine("1. 공격");
                Console.WriteLine(" ");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");



                // 입력
                string number = Console.ReadLine();

                switch (number) 
                {
                    // 1. 입력
                    case "1":

                        // Battle.ShowMonsterChoice() 수행 후 반환 값이 true일 때
                        if (true == ShowMonsterChoice())
                        {
                            // ShowBattle() 함수 나가기
                            return;
                        }
                            break;

                    // 1 제외 숫자 입력
                    default:

                        // "잘못된 입력입니다." 출력
                        Program.InputError();

                        // 문자 입력

                        // "잘못된 입력입니다." 출력
                        break;

                }

            }

        }

        bool ShowMonsterChoice()
        {
            // 무한 반복

                // "Battle!!" 문자열 출력

                // monsters의 크기만큼 반복
                
                    // Monster.ShowMonsterStatus() 호출

                // "[내정보]" 출력

                // Player.ShowDungeonStatus() 호출

                // 나머지 문자열 출력

                // 입력

                    // 1부터 monsters의 크기 사이의 정수 입력

                        // Battle.MonsterHit(monster) 수행 후 반환 값이 true일 경우

                            // Battle.PlayerVictory 수행 후 true 반환

                        // Battle.PlayerHit(monster) 수행 후 반환 값이 true일 경우

                            // Battle.PlayerLose 수행 후 true 반환

                    // 1부터 monsters의 크기 제외 숫자 입력

                        // "잘못된 입력입니다." 출력

                // 문자 입력

                    // "잘못된 입력입니다." 출력

            return false;   // bool을 반환 타입으로 갖는 함수는 항상 bool 값을 반환해야 함
        }
    }
}
