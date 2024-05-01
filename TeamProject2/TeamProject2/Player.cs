using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Player
    {
        public void ShowPlayerStatus()
        {
            GameManager exit = new GameManager();

            int Level = 01;
            string Name = "Chad";
            string Job = "전사";
            int Attack = 10;
            int Defense = 5;
            int HP = 100;
            int Gold = 1500;

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine(" ");
            Console.WriteLine($"Lv.{Level}");
            Console.WriteLine($"{Name} {Job}");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체  력 : {HP}");
            Console.WriteLine($"Gold : {Gold}");
            Console.WriteLine(" ");
            Console.WriteLine("0. 나가기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            string number = Console.ReadLine();

            switch (number)
            {
                case "0":
                    exit.ShowMainScene();
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;
            }
        }
    }
}
