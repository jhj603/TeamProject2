using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class GameManager
    {
        Player status;

        Battle battleScnen;

        public static int Choice(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
        }

        public void ShowMainScene()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("스파트라 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int Choice = GameManager.Choice(1, 2);

                switch (Choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
        }
    }
}
