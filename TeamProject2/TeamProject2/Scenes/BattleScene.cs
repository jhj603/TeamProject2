using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class BattleScene : Scene
    {
        List<Monster> monsters = new List<Monster>()
        {
            new Monster(2, "미니언", 15),
            new Monster(5, "대포미니언", 25),
            new Monster(3, "공허충", 10)
        };

        public override bool Initialize(Player playerInstance)
        {
            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 1, 1))
            {
                case 1:
                    ChoiceMonster();
                    break;
            }

            return SceneType.NoChange;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                Monster randomMonster = GetRandomMonster(monsters);
                Console.WriteLine($"Lv. {randomMonster.Lv} {randomMonster.Name} Hp {randomMonster.Hp}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("[내정보]");
            player.PrintStatus();
            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");
        }

        private void ChoiceMonster()
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine("Battle!");
                Console.WriteLine("");
                for (int i = 0; i < 3; i++)
                {
                    Monster randomMonster = GetRandomMonster(monsters);
                    Console.WriteLine($"-{i + 1} Lv. {randomMonster.Lv} {randomMonster.Name} Hp {randomMonster.Hp}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("[내정보]");
                player.PrintStatus();
                Console.WriteLine("");
                Console.WriteLine("0. 취소");
                Console.WriteLine("");
                Console.WriteLine("대상을 선택해주세요.");
                Console.WriteLine(">> ");

                //switch (MenuChoice("원하시는 행동을 입력해주세요.", 0, 3))
                //{
                //    case 0:
                //        // 턴넘기기
                //        break;
                //    case 1:
                //        player.Attack;
                //        break;
                //    case 2:
                //        player.Attack;
                //        break;
                //    case 3:
                //        player.Attack;
                //        break;
                //    default:
                //        break;
                //}
            }           
        }

        static Monster GetRandomMonster(List<Monster> monsters)
        {
            Random random = new Random();
            int index = random.Next(monsters.Count);
            return monsters[index];
        }
    }
}
