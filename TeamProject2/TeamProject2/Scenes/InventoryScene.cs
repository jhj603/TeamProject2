using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class InventoryScene
    {
        Player status = null;

        public InventoryScene(Player _status)
        {
            status = _status;
        }

        public void ShowInven()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("2. 포션 사용\n");

                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string strInput = Console.ReadLine();

                if ("0" == strInput)
                    return;
                else if ("1" == strInput)
                    PrintEquip();
                else if ("2" == strInput)
                    PrintUsePotion();
                else
                    Program.InputError();
            }
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

                status.PrintEquipable();

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("장착 또는 해제하고 싶은 장비를 입력해주세요.");
                Console.Write(">> ");

                maxCount = status.GetEquipSize();
                string strInput = Console.ReadLine();

                if (int.TryParse(strInput, out equipCount))
                {
                    if ((1 <= equipCount) && (maxCount >= equipCount))
                        status.Equip(equipCount - 1);
                    else if (0 == equipCount)
                        return;
                    else
                        Program.InputError();
                }
                else
                    Program.InputError();                
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

                status.PrintPotions();

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("사용하고 싶은 포션을 입력해주세요.");
                Console.Write(">> ");

                maxCount = status.GetPotionSize();
                string strInput = Console.ReadLine();

                if (int.TryParse(strInput, out potionCount))
                {
                    if ((1 <= potionCount) && (maxCount >= potionCount))
                        status.UsePotion(potionCount - 1);
                    else if (0 == potionCount)
                        return;
                    else
                        Program.InputError();
                }
                else
                    Program.InputError();
            }
        }
    }
}
