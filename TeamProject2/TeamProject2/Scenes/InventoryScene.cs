using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2.Scenes
{
    internal class InventoryScene : Scene
    {
        public override bool Initialize(Player playerInstance)
        {
            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 0, 2))
            {
                case 0:
                    return SceneType.Main;
                case 1:
                    PrintEquip();
                    break;
                case 2:
                    PrintUsePotion();
                    break;
            }

            return SceneType.NoChange;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("2. 포션 사용\n");

            Console.WriteLine("0. 나가기\n");
        }

        void PrintEquip()
        {
            int equipCount = 0;
            int maxCount = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 장비를 장착, 해제할 수 있습니다.\n");

                player.PrintEquipable();

                Console.WriteLine("\n0. 나가기\n");

                maxCount = player.GetEquipSize();
                equipCount = MenuChoice("장착 또는 해제하고 싶은 장비를 입력해주세요.", 0, maxCount);

                if ((1 <= equipCount) && (maxCount >= equipCount))
                    player.Equip(equipCount - 1);
                else if (0 == equipCount)
                    return;
            }
        }

        void PrintUsePotion()
        {
            int potionCount = 0;
            int maxCount = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리 - 포션 사용");
                Console.WriteLine("보유 중인 포션을 사용할 수 있습니다.\n");

                player.PrintPotions();

                Console.WriteLine("\n0. 나가기\n");

                maxCount = player.GetPotionSize();
                potionCount = MenuChoice("사용하고 싶은 포션을 입력해주세요.", 0, maxCount);

                if ((1 <= potionCount) && (maxCount >= potionCount))
                    player.UsePotion(potionCount - 1);
                else if (0 == potionCount)
                    return;
            }
        }
    }
}
