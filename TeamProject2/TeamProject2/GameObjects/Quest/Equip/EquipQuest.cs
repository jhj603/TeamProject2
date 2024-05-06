using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class EquipQuest : Quest
    {
        public ItemType GoalItemType { get; private set; }
        public string GoalItemName { get; private set; }

        public EquipQuest(int index, string name, ItemType goalItemType, string goalName, QuestState currentState, int rewardGold, List<KeyValuePair<ItemType, string>> rewardItemsInfo, string desc)
            : base(index, name, rewardGold, currentState, rewardItemsInfo, desc)
        {
            GoalItemType = goalItemType;
            GoalItemName = goalName;
        }

        public bool CheckFinish(ItemType itemType, string itemName)
        {
            if ((GoalItemType == itemType) && (GoalItemName == itemName))
                return true;

            return false;
        }
    }
}
