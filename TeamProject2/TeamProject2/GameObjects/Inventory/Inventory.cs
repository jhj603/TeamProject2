using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Inventory
    {
        public List<BaseItem> EquipableItems { get; private set; } = null;
        public List<BaseItem> Potions { get; private set; } = null;

        Dictionary<ItemType, BaseItem> equipItems = null;

        public Inventory()
        {
            EquipableItems = new List<BaseItem>();

            equipItems = new Dictionary<ItemType, BaseItem>();

            for (ItemType i = ItemType.Weapon; i < ItemType.Potion_HP; ++i)
                equipItems.Add(i, null);

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
                
            if (equipItems[EquipableItems[index - 1].Type] == EquipableItems[index - 1])
                equipItems[EquipableItems[index - 1].Type] = null;

            item = EquipableItems[index - 1];

            cost = (int)(item.Gold * 0.85f);

            EquipableItems.RemoveAt(index - 1);

            return item;
        }

        public void Equip(int index)
        {
            if (equipItems[EquipableItems[index].Type] == EquipableItems[index])
                equipItems[EquipableItems[index].Type] = null;
            else
                equipItems[EquipableItems[index].Type] = EquipableItems[index];
        }

        public BaseItem UsePotion(int index)
        {
            return Potions[index];
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

                if (equipItems[EquipableItems[i].Type] == EquipableItems[i])
                    Console.Write("[E] ");

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
