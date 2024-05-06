using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class HuntQuest : Quest
    {
        public int HuntCount { get; private set; } = 0;
        public int GoalCount { get; private set; }
        public MonsterType GoalMonsterType { get; private set; }

        public HuntQuest(int index, string name, int goal, MonsterType goalType, QuestState currentState, int rewardGold, List<KeyValuePair<ItemType, string>> rewardItemsInfo, string desc)
            : base(index, name, rewardGold, currentState, rewardItemsInfo, desc)
        {
            GoalCount = goal;
            GoalMonsterType = goalType;
        }

        public bool CheckFinish(Monster monster)
        {
            if (GoalMonsterType == monster.MonType)
                ++HuntCount;

            if (GoalCount <= HuntCount)
                return true;

            return false;
        }
    }
}
