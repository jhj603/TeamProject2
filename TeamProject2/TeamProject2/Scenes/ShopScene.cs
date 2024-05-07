using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class ShopScene
    {
        Player status = null;

        Shop shop = null;

        public ShopScene(Player _status)
        {
            status = _status;

            shop = new Shop();

            shop.Initialize();
        }

        public void ShowShop()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("상점");
                Console.ResetColor();
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{status.Gold}\n");
                Console.ResetColor();

                Console.WriteLine("[아이템 목록]");
                shop.PrintItemList();

                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매\n");

                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string strInput = Console.ReadLine();

                if ("1" == strInput)
                {
                    BuyItem();
                }
                else if ("2" == strInput)
                {
                    SellItem();
                }
                else if ("0" == strInput)
                {
                    return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }

        void BuyItem()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor= ConsoleColor.DarkCyan;
                Console.Write("상점");
                Console.ResetColor();
                Console.WriteLine(" - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{status.Gold}\n");
                Console.ResetColor();

                Console.WriteLine("[아이템 목록]");
                shop.PrintItemList(true);

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("사고싶은 아이템을 입력해주세요.");
                Console.Write(">> ");

                string strInput = Console.ReadLine();
                int inputNum;

                if (int.TryParse(strInput, out inputNum))
                {
                    if ((0 < inputNum) && (shop.Count >= inputNum))
                    {
                        if (shop.IsSell(inputNum - 1))
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        else if (shop.SellItems[inputNum - 1].Gold > status.Gold)
                            Console.WriteLine("잔액이 부족합니다..!");
                        else
                        {
                            status.BuyItem(shop.SellItems[inputNum - 1]);
                            shop.BuyItem(inputNum - 1);
                            Console.WriteLine("구매를 완료했습니다!");
                        }

                        Thread.Sleep(1000);
                    }
                    else if (0 == inputNum)
                        return;
                }
                else
                {
                    Program.InputError();
                }
            }
        }

        void SellItem()
        {
            int invenCount = 0;
            BaseItem sellItem = null;

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("상점");
                Console.ResetColor();
                Console.WriteLine(" - 아이템 판매");
                Console.WriteLine("필요없는 아이템을 팔 수 있는 상점입니다.\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{status.Gold}\n");
                Console.ResetColor();

                Console.WriteLine("[아이템 목록]");
                invenCount = status.ShowInventory(true);

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("팔고싶은 아이템을 입력해주세요.");
                Console.Write(">> ");

                string strInput = Console.ReadLine();
                int inputNum;

                if (int.TryParse(strInput, out inputNum))
                {
                    if ((0 < inputNum) && (shop.Count >= inputNum))
                        shop.SellItem(status.SellItem(inputNum));
                    else if (0 == inputNum)
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
