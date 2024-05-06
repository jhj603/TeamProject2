﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamProject2
{
    internal class BattleScene
    {
        Player status = null;               // 플레이어 객체가 비어있다. GameManager에서 받아와야 함.
        List<Monster> monsters = null;      // 몬스터 객체들을 모아놓는 리스트

        int startHP = 0;                    // 배틀 시작 시 플레이어의 hp

        public BattleScene(Player _status)
        {
            status = _status;
        }

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

        void MonsterHit(Monster monster)
        {       
            // 변수를 만들어서 현재 monster의 HP 저장
            int nowMonsterHp = monster.Hp;
            // Player.PlayerAttack(monster) 수행
            status.PlayerAttack(monster);
            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                // "Battle!!" 출력
                Program.ColorDarkRed("Battle!!\n\n");
                // 플레이어의 이름을 문자열 생성 후 출력
                Console.WriteLine($"{status.Name}의 공격");
                // 몬스터의 레벨, 이름, 플레이어의 데미지로 문자열 생성 후 출력
                Console.Write($"Lv. {monster.Level} {monster.Name}을(를) 맞췄습니다. [데미지 : {status.CurrentDamage}]");

                if (status.IsCritical)
                    Console.WriteLine(" - 치명타 공격!!\n");
                else
                    Console.WriteLine("\n");

                // 몬스터의 레벨, 이름을 문자열 생성 후 출력
                Console.WriteLine($"Lv. {monster.Level} {monster.Name}");

                if (monster.Hp == 0)
                {
                    Console.WriteLine($"HP {nowMonsterHp} -> Dead\n");
                }
                else
                {
                    Console.WriteLine($"HP {nowMonsterHp} -> {monster.Hp}\n");
                }

                Console.WriteLine("0. 다음\n");
                Console.Write(">> ");

                string input = Console.ReadLine();                     // 입력
                int num;

                if (int.TryParse(input, out num))
                {
                    if (num == 0)                                      // 0. 입력
                    {
                        return;                                   // true 반환
                    }
                    else                                               // 0 제외 숫자 입력
                    {
                        Program.InputError();                          // "잘못된 입력입니다." 출력
                    }
                }
                else                                                   // 문자 입력
                {
                    Program.InputError();                              // "잘못된 입력입니다." 출력
                }
            }
        }

        bool PlayerHit(Monster monster)
        {
            // 변수를 만들어서 현재 player의 HP 저장
            int nowPlayerHp = status.Hp;
            // Monster.MonsterAttack(player) 수행
            monster.MonsterAttack(status);
            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                // "Battle!!" 출력
                Program.ColorDarkRed("Battle!!\n\n");
                // 몬스터의 레벨, 이름을 문자열 생성 후 출력
                Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");
                // 플레이어의 이름, 몬스터의 데미지로 문자열 생성 후 출력
                Console.Write($"{status.Name}을(를) 맞췄습니다. [데미지 : {monster.CurrentDamage}]");

                if (monster.IsCritical)
                    Console.WriteLine(" - 치명타 공격!!\n");
                else
                    Console.WriteLine("\n");

                Console.WriteLine($"Lv.{status.Level} {status.Name}");

                if (status.Hp == 0)
                {
                    Console.WriteLine($"HP {nowPlayerHp} -> Dead\n");
                }
                else
                {
                    Console.WriteLine($"HP {nowPlayerHp} -> {status.Hp}\n");
                }

                Console.WriteLine("0. 다음\n");
                Console.Write(">> ");

                string input = Console.ReadLine();                     // 입력
                int num;

                if (int.TryParse(input, out num))
                {
                    if (num == 0)                                      // 0. 입력
                    {
                        return true;                                   // true 반환
                    }
                    else                                               // 0 제외 숫자 입력
                    {
                        Program.InputError();                          // "잘못된 입력입니다." 출력
                    }
                }
                else                                                   // 문자 입력
                {
                    Program.InputError();                              // "잘못된 입력입니다." 출력
                }
            }
            return false;
        }

        void PlayerVictory()
        {
            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                Program.ColorDarkRed("Battle ");
                Console.WriteLine("- Result\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Victory!");  // "Victory" 까지 문자열 출력
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");    // monsters의 크기로 "던전에서 몬스터 ~마리를 잡았습니다." 문자열 생성 후 출력
                Console.WriteLine();
                Console.WriteLine($"Lv. {status.Level} {status.Name}");    // player의 레벨, 이름 으로 문자열 생성 후 출력
                Console.WriteLine($"HP {startHP} -> {status.Hp}\n");    // starthHp와 player의 hp로 문자열 생성 후 출력

                // 나머지 문자열 출력

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                string input = Console.ReadLine();  // 입력
                int inputNum;

                if (int.TryParse(input, out inputNum))
                {
                    if (inputNum == 0)
                    {
                        return;    // PlayerVictory() 함수 나가기
                    }
                    else   // 0 제외 숫자 입력
                    {
                        Program.InputError();   // "잘못된 입력입니다." 출력
                    }
                }
                else    // 문자 입력
                {
                    Program.InputError();   // "잘못된 입력입니다." 출력
                }
            }
        }

        void PlayerLose()
        {
            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                // "You Lose" 까지 문자열 출력
                Program.ColorDarkRed("Battle ");
                Console.WriteLine("- Result\n");
                Program.ColorDarkRed("You Lose\n\n");
                // player의 레벨, 이름 으로 문자열 생성 후 출력
                Console.WriteLine($"Lv.{status.Level} {status.Name}");
                // starthHp와 player의 hp로 문자열 생성 후 출력
                Console.WriteLine($"HP {startHP} -> Dead\n");
                // 나머지 문자열 출력
                Console.WriteLine("0. 다음");
                Console.WriteLine();

                Console.Write(">> ");

                string input = Console.ReadLine();                     // 입력
                int num;

                if (int.TryParse(input, out num))
                {
                    if (num == 0)                                      // 0. 입력
                    {
                        return;                                        // PlayerLose() 함수 나가기
                    }
                    else                                               // 0 제외 숫자 입력
                    {
                        Program.InputError();                          // "잘못된 입력입니다." 출력
                    }
                }
                else                                                   // 문자 입력
                {
                    Program.InputError();                              // "잘못된 입력입니다." 출력
                }
            }
        }

        bool MonsterDeadCheck()
        {
            // monsters의 모든 몬스터가 죽었으면
            for (int i = 0; i < monsters.Count; ++i)
            {
                if (monsters[i].Hp > 0)    // 0번째가 HP 0이면 1, 2, 3번째 친구들을 검사하지 않습니다.
                {                           // 검사하는 친구 중 하나라도 HP가 0보다 크면 false를 반환
                    return false;
                }
            }

            return true;
        }

        public void ShowBattle()
        {
            // startHP에 현재 플레이어의 hp 저장
            startHP = status.Hp;

            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                // "Battle!!" 문자열 출력
                Program.ColorDarkRed("Battle!!\n\n");

                Console.WriteLine("=====================================");
                // monsters의 크기만큼 반복
                for (int i = 0; i < monsters.Count; i++)
                {
                    // Monster.ShowMonsterStatus() 호출
                    monsters[i].ShowMonsterStatus();
                }              
                Console.WriteLine("=====================================");
                Console.WriteLine();

                // "[내정보]" 출력
                Console.WriteLine("[내정보]");

                // Player.ShowDungeonStatus() 호출
                status.ShowDungeonStatus();

                // 나머지 문자열 출력
                Console.WriteLine();
                Console.WriteLine("1. 공격");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

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
                        break;
                }

            }

        }

        bool ShowMonsterChoice()
        {
            // 무한 반복
            while (true)
            {
                // 콘솔 창 출력 지워줌.
                Console.Clear();

                // "Battle!!" 문자열 출력
                Program.ColorDarkRed("Battle!!\n\n");

                Console.WriteLine("=====================================");
                // monsters의 크기만큼 반복
                for (int i = 0; i < monsters.Count; i++)
                {
                    // Monster.ShowMonsterStatus() 호출
                    Console.Write($"{i + 1} ");
                    monsters[i].ShowMonsterStatus();        // 숫자를 앞에 붙여 선택할 수 있게 해야 함
                }
                Console.WriteLine("=====================================");
                Console.WriteLine();

                // "[내정보]" 출력
                Console.WriteLine("[내정보]");

                // Player.ShowDungeonStatus() 호출
                status.ShowDungeonStatus();

                // 나머지 문자열 출력
                Console.WriteLine();
                Console.WriteLine("0. 취소\n");
                Console.WriteLine("대상을 선택해주세요.\n");
                Console.Write(">> ");

                string input = Console.ReadLine();                               // 입력
                int num;

                if (int.TryParse(input, out num))
                {
                    if (num > 0 && num <= monsters.Count)                       // 1부터 monsters의 크기 사이의 정수 입력
                    {
                        // 몬스터가 죽었으면 잘못 골랐다는 에러 메시지 출력
                        if (0 == monsters[num - 1].Hp)
                        {
                            Console.WriteLine("이미 죽은 몬스터입니다.");

                            Thread.Sleep(1000);

                            continue;
                        }
                        else
                        {
                            if (monsters[num - 1].IsDodge())
                                PrintMonsterDodge(monsters[num - 1]);
                            else
                            {
                                // Battle.MonsterHit(monster) 수행
                                MonsterHit(monsters[num - 1]);
                                // monsters의 모든 몬스터가 죽었으면   bool MonsterDeadCheck
                                if (true == MonsterDeadCheck())
                                {
                                    // Battle.PlayerVictory 수행 후 true 반환
                                    PlayerVictory();
                                    return true;
                                }
                            }
                        }

                        // monsters의 크기만큼 반복
                        for (int i = 0; i < monsters.Count; ++i)
                        {
                            // 안죽은 몬스터면 공격을 해라
                            if (0 < monsters[i].Hp)
                            {
                                if (status.IsDodge())
                                {
                                    PrintPlayerDodge(monsters[i]);
                                }
                                else
                                {
                                    // Battle.PlayerHit(monster) 수행
                                    PlayerHit(monsters[i]);
                                    // player가 죽었으면
                                    if (0 == status.Hp)
                                    {
                                        // Battle.PlayerLose 수행 후 true 반환
                                        PlayerLose();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    // 1부터 monsters의 크기 사이의 정수가 아니라 0이 입력되면 돌아가기
                    else if (0 == num)
                    {
                        return false;
                    }
                    else                                                        // 0도 아니고 1부터 monsters의 크기 제외 숫자 입력
                    {
                        Program.InputError();                                       // "잘못된 입력입니다." 출력
                    }
                }
                else                                                            // 문자 입력
                {
                    Program.InputError();                                       // "잘못된 입력입니다." 출력
                }
            }

            return false;   // bool을 반환 타입으로 갖는 함수는 항상 bool 값을 반환해야 함
        }

        void PrintMonsterDodge(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                Console.WriteLine($"{status.Name} 의 공격!");
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");

                Console.WriteLine("0. 다음");

                string input = Console.ReadLine();                     // 입력

                if ("0" == input)
                {
                    return;
                }
                else                                                   // 문자 입력
                {
                    Program.InputError();                              // "잘못된 입력입니다." 출력
                }
            }
        }

        void PrintPlayerDodge(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
                Console.WriteLine($"{status.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");

                Console.WriteLine("0. 다음");

                string input = Console.ReadLine();

                if ("0" == input)
                {
                    return;
                }
                else                                                   // 문자 입력
                {
                    Program.InputError();                              // "잘못된 입력입니다." 출력
                }
            }
        }
    }
}
