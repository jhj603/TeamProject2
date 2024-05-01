﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class GameManager
    {
        Player player = new Player();

        Battle battle = new Battle();

        public void ShowMainScene()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("스파트라 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    ShowPlayerStatus();
                }
                else if (userInput == "2")
                {
                    battle.ShowBattle();
                }
                else
                {
                    Program.InputError();
                }
            }
        }
        public void ShowPlayerStatus()
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                player.ShowStatus();

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string userinput = Console.ReadLine();

                if (userinput == "0")
                {
                    return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }
    }
}
