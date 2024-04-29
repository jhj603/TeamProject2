using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamProject2.GameObjects.Player;

namespace TeamProject2.Scenes
{
    internal class BattleScene
    {
        List<Monster> monsters = new List<Monster>()
        {
            new Monster(2, "미니언", 15),
            new Monster(5, "대포미니언", 25),
            new Monster(3, "공허충", 10)
        };

        public void Battle()
        {
            Console.Clear();

            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                Monster randomMonster = GetRandomMonster(monsters);
                Console.WriteLine ($"Lv. {randomMonster.Lv} {randomMonster.Name} Hp {randomMonster.Hp}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("[내정보]");
            //Console.WriteLine(Player.BattleState); //변수로 플레이어도 객체로 있어야한다.?
            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            //// 버튼 메서드를 만들었을 때?
            //switch ()
            //{
            //    case 1:
            //        ChoiceMonster();
            //        break;
            //}
        }

        private void ChoiceMonster()
        {
            Console.Clear ();

            Console.WriteLine("Battle!");
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                Monster randomMonster = GetRandomMonster(monsters);
                Console.WriteLine($"-{i + 1} Lv. {randomMonster.Lv} {randomMonster.Name} Hp {randomMonster.Hp}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("[내정보]");
            //Console.WriteLine(Player.BattleState);
            Console.WriteLine("");
            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            Console.WriteLine("대상을 선택해주세요.");
            Console.WriteLine(">> ");

            //switch (Choice(0, 3))
            //{
            //    case 0;
            //        Battle();
            //        break;
            //    case 1:
            //        Player.Attack();
            //        break;
            //    case 2:
            //        Player.Attack();
            //        break;
            //    case 3:
            //        Player.Attack();
            //        break;
            //    default:
            //        break;
            //}
        }

        static Monster GetRandomMonster(List<Monster> monsters)
        {
            Random random = new Random();
            int index = random.Next(monsters.Count);
            return monsters[index];
        }
    }

    internal class Monster // GameObjects의 Monsters.cs로 가야함 (그리고 using TeamProject2.GameObjects.Monster 추가)
    {
        public int Lv { get; }
        public string Name { get; }
        public int Hp { get; set; }


        public Monster(int lv, string name, int hp)
        {
            Lv = lv;
            Name = name;
            Hp = hp;
        }
    }
}
