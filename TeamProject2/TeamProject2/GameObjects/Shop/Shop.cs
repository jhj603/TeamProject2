using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Shop
    {
        public int Count { get; private set; }

        public List<BaseItem> SellItems { get; private set; } = null;

        Dictionary<string, int> itemDict = null;

        public bool Initialize()
        {
            SellItems = new List<BaseItem>();

            ItemManager itemManager = ItemManager.GetInstance();

            if (null == itemManager)
                return false;

            itemManager.AddItems(SellItems);

            Count = SellItems.Count;

            itemDict = new Dictionary<string, int>();

            foreach (BaseItem item in SellItems)
            {
                if (itemDict.ContainsKey(item.Name))
                    ++itemDict[item.Name];
                else
                    itemDict.Add(item.Name, 1);
            }

            return true;
        }

        public bool IsSell(int itemIndex)
        {
            if (0 == itemDict[SellItems[itemIndex].Name])
                return true;

            return false;
        }

        public void BuyItem(int itemIndex)
        {
            if (ItemType.Potion_HP > SellItems[itemIndex].Type)
                --itemDict[SellItems[itemIndex].Name];
        }

        public void SellItem(BaseItem item)
        {
            if (ItemType.Potion_HP > item.Type)
                ++itemDict[item.Name];
        }

        public void PrintItemList(bool isIndex = false)
        {
            int i = 1;

            foreach (BaseItem item in SellItems)
            {
                Console.Write(" - ");

                if (isIndex)
                {
                    Console.Write($"[{i}] ");
                    ++i;
                }

                item.PrintItemInfo();

                if (0 == itemDict[item.Name])
                    Console.WriteLine("|구매 완료");
                else
                    Console.WriteLine($"|{item.Gold} G");
            }
        }
    }
}
