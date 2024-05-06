using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum QuestState
    {
        StandBy,
        Progress,
        CanFinish,
        Finish
    }


    internal abstract class Quest
    {
        public string Name { get; protected set; }
        public string Desc { get; protected set; }
        public int Index { get; protected set; }
        public int RewardGold { get; protected set; }
        public QuestState CurrentState { get; set; }

        protected List<BaseItem> rewardItems = null;

        public Quest(int index, string name, int rewardGold, QuestState currentState, List<KeyValuePair<ItemType, string>> rewardItemsInfo, string desc)
        {
            Index = index;
            Name = name;
            Desc = desc;
            RewardGold = rewardGold;
            CurrentState = currentState;

            if (null != rewardItemsInfo)
            {
                rewardItems = new List<BaseItem>();

                ItemManager itemManager = ItemManager.GetInstance();

                if (null != itemManager)
                {
                    foreach (KeyValuePair<ItemType, string> itemInfo in rewardItemsInfo)
                        rewardItems.Add(new BaseItem(itemManager.FindItem(itemInfo.Key, itemInfo.Value)));
                }
            }
        }

        public void PrintShortInfo()
        {
            Console.Write($"{Index}. {Name} - ");

            switch (CurrentState)
            {
                case QuestState.StandBy:
                    Console.WriteLine("수락 가능");
                    break;
                case QuestState.Progress:
                    Console.WriteLine("진행 중");
                    break;
                case QuestState.CanFinish:
                    Console.WriteLine("완료 가능");
                    break;
                case QuestState.Finish:
                    Console.WriteLine("완료");
                    break;
            }
        }

        public abstract void PrintGoal();

        public void PrintRewards()
        {
            Console.WriteLine("- 보상 -");

            foreach (BaseItem item in rewardItems)
                Console.WriteLine(item.Name);

            Console.WriteLine($"{RewardGold} G");
        }

        public void GetRewards(Player player)
        {
            player.Gold += RewardGold;

            foreach (BaseItem item in rewardItems)
                player.GetItem(item);
        }
    }
}
