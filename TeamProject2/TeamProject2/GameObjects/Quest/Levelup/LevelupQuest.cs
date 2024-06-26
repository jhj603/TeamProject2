﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class LevelupQuest : Quest
    {
        public int GoalLevel { get; private set; }

        public LevelupQuest(int index, string name, int goal, QuestState currentState, int rewardGold, List<KeyValuePair<ItemType, string>> rewardItemsInfo, string desc)
            : base(index, name, rewardGold, currentState, rewardItemsInfo, desc)
        {
            GoalLevel = goal;
        }

        public void CheckFinish(int playerLevel)
        {
            if (GoalLevel <= playerLevel)
                CurrentState = QuestState.CanFinish;
        }

        public override void PrintGoal()
        {
            Console.WriteLine($" - {GoalLevel} 레벨 달성");
        }
    }
}
