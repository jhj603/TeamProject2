using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum ItemType
    {
        Weapon,
        Armor_Head,
        Armor_Chest,
        Armor_Pants,
        Potion_HP,
        Potion_MP,
        Potion_Atk,
        Potion_Dfs,
        Potion_Exp,
        ItemTypeEnd
    }

    internal class BaseItem
    {
        public string Name { get; private set; }
        public string Desc { get; private set; }
        public ItemType Type { get; private set; }
        public int Gold { get; private set; }
        public int Increase { get; private set; }

        public BaseItem(string name, string desc, ItemType type, int increase, int gold)
        {
            Name = name;
            Desc = desc;
            Type = type;
            Gold = gold;
            Increase = increase;
        }

        public BaseItem(BaseItem item)
        {
            Name = item.Name;
            Desc = item.Desc;
            Type = item.Type;
            Gold = item.Gold;
            Increase = item.Increase;
        }

        public void PrintItemInfoShop()
        {
            Console.Write($"{Name, 14}\t|");
            switch (Type)
            {
                case ItemType.Weapon:
                    Console.Write($"{"공격력",6}+{Increase}\t|");
                    break;
                case ItemType.Armor_Head:
                case ItemType.Armor_Chest:
                case ItemType.Armor_Pants:
                    Console.Write($"{"방어력", 6}+{Increase}\t|");
                    break;
                case ItemType.Potion_Atk:
                    Console.Write($"{"공격력 영구", 7}+{Increase}\t|");
                    break;
                case ItemType.Potion_Dfs:
                    Console.Write($"{"방어력 영구", 7}+{Increase}\t|");
                    break;
                case ItemType.Potion_Exp:
                    Console.Write($"{"경험치", 6}+{Increase}\t|");
                    break;
                case ItemType.Potion_HP:
                    Console.Write($"{"체력", 6}+{Increase}\t|");
                    break;
                case ItemType.Potion_MP:
                    Console.Write($"{"MP", 6}+{Increase}\t|");
                    break;
            }
            Console.Write($"{Desc, 28}\t");
        }
        public void PrintItemInfoInven()
        {
            Console.Write($"{Name, 16}\t|");
            switch (Type)
            {
                case ItemType.Weapon:
                    Console.Write($"{"공격력",6}+{Increase}\t|");
                    break;
                case ItemType.Armor_Head:
                case ItemType.Armor_Chest:
                case ItemType.Armor_Pants:
                    Console.Write($"{"방어력",6}+{Increase}\t|");
                    break;
                case ItemType.Potion_Atk:
                    Console.Write($"{"공격력 영구",7}+{Increase}\t|");
                    break;
                case ItemType.Potion_Dfs:
                    Console.Write($"{"방어력 영구",7}+{Increase}\t|");
                    break;
                case ItemType.Potion_Exp:
                    Console.Write($"{"경험치",6}+{Increase}\t|");
                    break;
                case ItemType.Potion_HP:
                    Console.Write($"{"체력",6}+{Increase}\t|");
                    break;
                case ItemType.Potion_MP:
                    Console.Write($"{"MP",6}+{Increase}\t|");
                    break;
            }
            Console.Write($"{Desc}\t");
        }
    }
}
