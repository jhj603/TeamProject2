using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class ItemManager
    {
        private static ItemManager Instance = null;

        Dictionary<ItemType, List<BaseItem>> itemDict = null;

        Random rand = null;

        private ItemManager()
        {
            itemDict = new Dictionary<ItemType, List<BaseItem>>();

            for (ItemType itemType = ItemType.Weapon; itemType <= ItemType.Potion_Exp; ++itemType)
                itemDict.Add(itemType, new List<BaseItem>());

            itemDict[ItemType.Weapon].Add(new BaseItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", ItemType.Weapon, 2, 600));
            itemDict[ItemType.Weapon].Add(new BaseItem("낡은 활", "어디서든 볼 수 있는 낡은 활입니다.", ItemType.Weapon, 2, 600));
            itemDict[ItemType.Weapon].Add(new BaseItem("오래된 지팡이", "많은 이들의 손을 거친 지팡이입니다.", ItemType.Weapon, 2, 600));

            itemDict[ItemType.Weapon].Add(new BaseItem("바스타드 소드", "검이라고 생각하기 어렵습니다.", ItemType.Weapon, 10, 2500));
            itemDict[ItemType.Weapon].Add(new BaseItem("초승달", "고대 엘프들이 직접 만든 활입니다.", ItemType.Weapon, 15, 3000));
            itemDict[ItemType.Weapon].Add(new BaseItem("불길한 스태프", "어딘가 불길함이 느껴지는 스태프입니다.", ItemType.Weapon, 20, 3500));

            itemDict[ItemType.Armor_Head].Add(new BaseItem("철 투구", "투박한 철 투구입니다.(생각보다 단단합니다.)", ItemType.Armor_Head, 5, 1000));
            itemDict[ItemType.Armor_Chest].Add(new BaseItem("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", ItemType.Armor_Chest, 9, 2000));
            itemDict[ItemType.Armor_Pants].Add(new BaseItem("사슬 바지", "치명상을 막아줄 수 있는 사슬 바지입니다.", ItemType.Armor_Pants, 7, 1500));

            itemDict[ItemType.Potion_Atk].Add(new BaseItem("프로틴 물약", "마시면 공격력이 상승할 것 같은 물약입니다.", ItemType.Potion_Atk, 3, 500));
            itemDict[ItemType.Potion_Dfs].Add(new BaseItem("경질화 물약", "마시면 몸이 단단해지는 물약입니다.", ItemType.Potion_Dfs, 3, 500));
            itemDict[ItemType.Potion_HP].Add(new BaseItem("회복 물약", "마시면 체력을 회복시켜 주는 물약입니다.", ItemType.Potion_HP, 10, 1000));
            itemDict[ItemType.Potion_MP].Add(new BaseItem("마나 회복 물약", "마시면 MP를 회복시켜 주는 물약입니다.", ItemType.Potion_MP, 10, 1000));
            itemDict[ItemType.Potion_Exp].Add(new BaseItem("경험의 물약", "마시면 경험치를 증가시키는 물약입니다.", ItemType.Potion_Exp, 30, 3000));

            rand = new Random();
        }

        public static ItemManager GetInstance()
        {
            if (null == Instance)
                Instance = new ItemManager();

            return Instance;
        }

        public void AddItems(List<BaseItem> items)
        {
            foreach (KeyValuePair<ItemType, List<BaseItem>> typeItems in itemDict)
            {
                foreach (BaseItem item in typeItems.Value)
                    items.Add(new BaseItem(item));
            }
        }

        public BaseItem FindItem(ItemType type, string name)
        {
            BaseItem findItem = null;

            foreach (BaseItem item in itemDict[type])
            {
                if (name == item.Name)
                    findItem = item;
            }

            return findItem;
        }

        public BaseItem GetRandomItem(ItemType type)
        {
            BaseItem randomItem = null;

            int randomIndex = rand.Next(0, itemDict[type].Count);

            randomItem = itemDict[type][randomIndex];

            return randomItem;
        }
    }
}
