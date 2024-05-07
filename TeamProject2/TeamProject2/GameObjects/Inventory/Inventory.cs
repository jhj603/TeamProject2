using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Inventory
    {
        public List<BaseItem> EquipableItems { get; private set; } = null;
        public List<BaseItem> Potions { get; private set; } = null;

        public Dictionary<ItemType, BaseItem> EquipItems = null;

        Player status = null;

        public Inventory(Player _status)
        {
            status = _status;

            EquipableItems = new List<BaseItem>();

            EquipItems = new Dictionary<ItemType, BaseItem>();

            for (ItemType i = ItemType.Weapon; i < ItemType.Potion_HP; ++i)
                EquipItems.Add(i, null);

            Potions = new List<BaseItem>();
        }

        public void AddItem(BaseItem item)
        {
            if (ItemType.Potion_HP > item.Type)
                EquipableItems.Add(new BaseItem(item));
            else
                Potions.Add(new BaseItem(item));
        }

        public BaseItem SellItem(int index, out int cost)
        {
            BaseItem item = null;

            if (EquipableItems.Count < index)
            {
                item = Potions[index - EquipableItems.Count - 1];

                cost = (int)(item.Gold * 0.85f);

                Potions.RemoveAt(index - EquipableItems.Count - 1);

                return item;
            }

            if (EquipItems[EquipableItems[index - 1].Type] == EquipableItems[index - 1])
                EquipItems[EquipableItems[index - 1].Type] = null;

            item = EquipableItems[index - 1];

            cost = (int)(item.Gold * 0.85f);

            EquipableItems.RemoveAt(index - 1);

            return item;
        }

        public void Equip(int index)
        {
            if (EquipItems[EquipableItems[index].Type] == EquipableItems[index])
            {
                if (ItemType.Weapon == EquipableItems[index].Type)
                    status.IncreaseAtk -= EquipableItems[index].Increase;
                else
                    status.IncreaseDfs -= EquipableItems[index].Increase;

                EquipItems[EquipableItems[index].Type] = null;
            }
            else
            {
                if (null != EquipItems[EquipableItems[index].Type])
                {
                    if (ItemType.Weapon == EquipableItems[index].Type)
                        status.IncreaseAtk -= EquipItems[EquipableItems[index].Type].Increase;
                    else
                        status.IncreaseDfs -= EquipItems[EquipableItems[index].Type].Increase;
                }

                EquipItems[EquipableItems[index].Type] = EquipableItems[index];

                if (ItemType.Weapon == EquipableItems[index].Type)
                    status.IncreaseAtk += EquipableItems[index].Increase;
                else
                    status.IncreaseDfs += EquipableItems[index].Increase;

                QuestManager questManager = QuestManager.GetInstance();

                if (null != questManager)
                {
                    EquipQuest equipQuest = null;

                    foreach (Quest quest in questManager.ProgressList)
                    {
                        equipQuest = (quest as EquipQuest);

                        if (null != equipQuest)
                            equipQuest.CheckFinish(EquipableItems[index].Type, EquipableItems[index].Name);
                    }
                }
            }
        }

        public BaseItem UsePotion(int index)
        {
            BaseItem item = Potions[index];

            Potions.RemoveAt(index);

            return item;
        }

        public int PrintInven(bool isIndex = false)
        {
            int i = 1;

            foreach (BaseItem item in EquipableItems)
            {
                Console.Write(" - ");

                if (isIndex)
                {
                    Console.Write($"[{i}] ");
                    ++i;
                }

                item.PrintItemInfo();

                Console.WriteLine($"|{item.Gold * 0.85f} G");
            }

            Console.WriteLine();

            foreach (BaseItem item in Potions)
            {
                Console.Write(" - ");

                if (isIndex)
                {
                    Console.Write($"[{i}] ");
                    ++i;
                }

                item.PrintItemInfo();

                Console.WriteLine($"|{item.Gold * 0.85f} G");
            }

            return EquipableItems.Count + Potions.Count;
        }

        public void PrintEquip()
        {
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < EquipableItems.Count; ++i)
            {
                Console.Write($" - {i + 1} ");

                if (EquipItems[EquipableItems[i].Type] == EquipableItems[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[E] ");
                    Console.ResetColor();
                }

                EquipableItems[i].PrintItemInfo();

                Console.WriteLine();
            }
        }

        public void PrintPotions()
        {
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Potions.Count; ++i)
            {
                Console.Write($" - {i + 1} ");

                Potions[i].PrintItemInfo();

                Console.WriteLine();
            }
        }
    }
}
