using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2.Scenes
{
    internal class ShopScene : Scene
    {
        Shop shop = null;

        public override bool Initialize(Player playerInstance)
        {
            if (null == shop)
            {
                shop = new Shop();

                if (!shop.Initialize())
                    return false;
            }

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
                    BuyItem();
                    break;
                case 2:
                    SellItem();
                    break;
            }

            return SceneType.NoChange;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold}\n");
            
            Console.WriteLine("[아이템 목록]");
            shop.PrintItemList();

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매\n");

            Console.WriteLine("0. 나가기\n");
        }

        void BuyItem()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold}\n");

                Console.WriteLine("[아이템 목록]");
                shop.PrintItemList(true);

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");

                int menuChoice = MenuChoice("원하시는 행동을 입력해주세요.", 0, shop.Count);
                Console.WriteLine();

                if ((1 <= menuChoice) && (shop.Count >= menuChoice))
                {
                    if (shop.IsSell(menuChoice - 1))
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    else if (shop.SellItems[menuChoice - 1].Gold > player.Gold)
                        Console.WriteLine("잔액이 부족합니다..!");
                    else
                    {
                        player.BuyItem(shop.SellItems[menuChoice - 1]);
                        shop.BuyItem(menuChoice - 1);
                        Console.WriteLine("구매를 완료했습니다!");
                    }

                    Thread.Sleep(1000);
                }
                else if (0 == menuChoice)
                    return;
            }
        }

        void SellItem()
        {
            int invenCount = 0;
            BaseItem sellItem = null;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요없는 아이템을 팔 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Gold}\n");

                Console.WriteLine("[아이템 목록]");
                invenCount = player.PrintInventory(true);

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");

                int menuChoice = MenuChoice("원하시는 행동을 입력해주세요.", 0, invenCount);
                Console.WriteLine();

                if ((1 <= menuChoice) && (invenCount >= menuChoice))
                    shop.SellItem(player.SellItem(menuChoice));
                else if (0 == menuChoice)
                    return;
            }
        }
    }
}
