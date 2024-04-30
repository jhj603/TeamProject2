using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamProject2
{
    internal class BattleScene : Scene
    {
        private List<Monster> selectedMonsters = new List<Monster>();

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
            selectedMonsters.Clear();
            for (int i = 0; i < 3; i++)         // 잘못입력했을때 다시 랜덤하게 몬스터들이 생김
            {
                Monster randomMonster = GetRandomMonster(monsters);
                Console.WriteLine($"Lv. {randomMonster.Lv} {randomMonster.Name} Hp {randomMonster.Hp}");
                selectedMonsters.Add(randomMonster);
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
                Console.WriteLine($"{1} Lv. {selectedMonsters[0].Lv} {selectedMonsters[0].Name} Hp {selectedMonsters[0].Hp}");
                Console.WriteLine($"{2} Lv. {selectedMonsters[1].Lv} {selectedMonsters[1].Name} Hp {selectedMonsters[1].Hp}");
                Console.WriteLine($"{3} Lv. {selectedMonsters[2].Lv} {selectedMonsters[2].Name} Hp {selectedMonsters[2].Hp}");
                Console.WriteLine("\n");
                Console.WriteLine("[내정보]");
                player.PrintStatus();
                Console.WriteLine("");
                Console.WriteLine("0. 취소");
                Console.WriteLine("");

                switch (MenuChoice("대상을 선택해주세요..", 0, 3))
                {
                    case 0:
                        break;
                    case 1:
                        PlayerAttack(selectedMonsters[0]);
                        break;
                    //case 2:
                    //    PlayerAttack(selectedMonsters[1]);
                    //    break;
                    //case 3:
                    //    PlayerAttack(selectedMonsters[2]);
                    //    break;
                    //default:
                    //    break;
                }
            }
        }

        private void PlayerAttack(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!");
                Console.WriteLine("");
                player.PlayerName();
                Console.WriteLine($"Lv. {selectedMonsters[0].Lv} {selectedMonsters[0].Name} 을(를) 맞췄습니다. [데미지 : {player.Attack}]"); //player.Attack을 오차범위 주기
                Console.WriteLine("");
                Console.WriteLine($"Lv. {selectedMonsters[0].Lv} {selectedMonsters[0].Name}");
                int newHp = selectedMonsters[0].Hp - player.Attack;
                if (newHp <= 0)
                {
                    Console.WriteLine($"HP {selectedMonsters[0].Hp} -> Dead");
                    selectedMonsters[0].Hp = int.Parse("Dead");              // 돌아갔을 때 dead가 안뜬다
                }
                else
                {
                    Console.WriteLine($"HP {selectedMonsters[0].Hp} -> {newHp}");
                    selectedMonsters[0].Hp = newHp;
                }
                Console.WriteLine("");
                Console.WriteLine("0. 다음");

                switch (MenuChoice("", 0, 0))
                {
                    case 0:
                        ChoiceMonster();
                        break;
                }
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
