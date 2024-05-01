using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Battle
    {
        Player player = new Player();

        List<Monster> monsters = new List<Monster>()
        {
            new Monster(2, "미니언", 15, 5, ""),
            new Monster(3, "공허충", 10, 9, ""),
            new Monster(5, "대포미니언", 25, 8, "")
        };

        public void ShowBattle()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                for (int i = 0; i < monsters.Count; i++)
                {
                    monsters[i].ShowMonsterStatus();
                }

                Console.WriteLine();

                player.ShowDunGeonStatus();

                Console.WriteLine("\n1. 공격\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    ShowMonsterChoice();
                }
                else
                {
                    Program.InputError();
                }
            }
        }
        
        public void ShowMonsterChoice()
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n");

            for (int i = 0; i < monsters.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                monsters[i].ShowMonsterStatus();
            }

            Console.WriteLine();

            player.ShowDunGeonStatus();

            Console.WriteLine("\n0. 취소\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string userInput = Console.ReadLine();

            if (userInput == "0")
            {
                PlayerHitResult();
            }
            else if (userInput == "1")
            {
                MonsterHitResult1();
            }
            else if (userInput == "2")
            {
                MonsterHitResult2();
            }
            else if (userInput == "3")
            {
                MonsterHitResult3();
            }
            else
            {
                Program.InputError();
            }
        }

        public void MonsterHitResult1()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                player.PlayerAttack();
                Console.WriteLine($"Lv.{monsters[0].Level} {monsters[0].Name}을(를) 맞췄습니다. [데미지 : {player.Attack}]\n");

                monsters[0].Hp -= player.Attack;
                if (monsters[0].Hp <= 0)
                {
                    monsters[0].Hp = 0;
                    monsters[0].State = "-> Dead";
                    Console.WriteLine($"Lv.{monsters[0].Level} {monsters[0].Name}");
                    Console.WriteLine($"HP Dead");
                }
                else
                {
                    Console.WriteLine($"Lv.{monsters[0].Level} {monsters[0].Name}");
                    Console.WriteLine($"남은HP {monsters[0].Hp}");
                }

                Console.WriteLine("\n0. 다음\n");
                Console.Write(">> ");

                string userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    PlayerHitResult();
                    return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }
        public void MonsterHitResult2()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                player.PlayerAttack();
                Console.WriteLine($"Lv.{monsters[1].Level} {monsters[1].Name}을(를) 맞췄습니다. [데미지 : {player.Attack}]\n");

                monsters[1].Hp -= player.Attack;
                if (monsters[1].Hp <= 0)
                {
                    monsters[1].Hp = 0;
                    monsters[1].State = "-> Dead";
                    Console.WriteLine($"Lv.{monsters[1].Level} {monsters[1].Name}");
                    Console.WriteLine($"HP Dead");
                }
                else
                {
                    Console.WriteLine($"Lv.{monsters[1].Level} {monsters[1].Name}");
                    Console.WriteLine($"남은HP {monsters[1].Hp}");
                }

                Console.WriteLine("\n0. 다음\n");
                Console.Write(">> ");

                string userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    PlayerHitResult();
                    return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }
        public void MonsterHitResult3()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                player.PlayerAttack();
                Console.WriteLine($"Lv.{monsters[2].Level} {monsters[2].Name}을(를) 맞췄습니다. [데미지 : {player.Attack}]\n");

                monsters[2].Hp -= player.Attack;
                if (monsters[2].Hp <= 0)
                {
                    monsters[2].Hp = 0;
                    monsters[2].State = "-> Dead";
                    Console.WriteLine($"Lv.{monsters[2].Level} {monsters[2].Name}");
                    Console.WriteLine($"HP -> Dead");
                }
                else
                {
                    Console.WriteLine($"Lv.{monsters[2].Level} {monsters[2].Name}");
                    Console.WriteLine($"남은HP {monsters[2].Hp}");
                }

                Console.WriteLine("\n0. 다음\n");
                Console.Write(">> ");

                string userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    PlayerHitResult();
                    return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }
        public void PlayerHitResult()
        {
            Console.Clear();

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Hp > 0)
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("Battle!!\n");
                        Console.WriteLine($"Lv. {monsters[i].Level} {monsters[i].Name}의 공격!");
                        Console.WriteLine($"{player.Name}을(를) 맞췄습니다. [데미지 : {monsters[i].Attack}]\n");

                        player.Hp -= monsters[i].Attack;
                        if (player.Hp > 0)
                        {
                            Console.WriteLine($"Lv. {player.Level} {player.Name}\n");
                            Console.WriteLine($"남은HP {player.Hp}\n");

                        }
                        else
                        {
                            player.Hp = 0;
                            BattleResult();
                        }

                        Console.WriteLine("0. 다음\n");
                        Console.Write(">> ");

                        string userInput = Console.ReadLine();

                        if (userInput == "0")
                        {
                            break;
                        }
                        else
                        {
                            Program.InputError();
                        }
                    }
                }
                else if (monsters[0].Hp <= 0 && monsters[1].Hp <= 0 && monsters[2].Hp <= 0)
                {
                    BattleResult();
                }
            }
        }

        private void BattleResult()
        {
            if (player.Hp <= 0)
            {
                while (true)
                {
                    Console.Clear ();

                    Console.WriteLine("Battle!! - Result\n");
                    Console.WriteLine("You Lose\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP 100 -> {player.Hp}\n");
                    Console.WriteLine("0. 다음\n");
                    Console.Write(">> ");

                    string userInput = Console.ReadLine();

                    if (userInput == "0")
                    {
                        // 
                    }
                    else
                    {
                        Program.InputError();
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!! - Result\n");
                    Console.WriteLine("Victory\n");
                    Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.\n");
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP 100 -> {player.Hp}\n");
                    Console.WriteLine("0. 다음\n");
                    Console.Write(">> ");

                    string userInput = Console.ReadLine();

                    if (userInput == "0")
                    {

                    }
                    else
                    {
                        Program.InputError();
                    }
                }
            }
        }
    }
}
