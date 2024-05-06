using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class QuestManager
    {
        private static QuestManager Instance = null;

        List<Quest> questList = null;

        private QuestManager()
        {
            questList = new List<Quest>();

            List<KeyValuePair<ItemType, string>> rewards = new List<KeyValuePair<ItemType, string>>();

            rewards.Add(new KeyValuePair<ItemType, string>(ItemType.Weapon, "낡은 검"));
            questList.Add(new HuntQuest(
                1,
                "마을을 위협하는 미니언 처치",
                5,
                MonsterType.Minion,
                QuestState.StandBy, 
                5,
                rewards,
                "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                "마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                "모험가인 자네가 좀 처치해주게!\n"
                ));

            rewards.Clear();
            rewards.Add(new KeyValuePair<ItemType, string>(ItemType.Armor_Head, "철 투구"));
            questList.Add(new EquipQuest(
                2,
                "장비를 장착해보자",
                ItemType.Weapon,
                "낡은 검",
                QuestState.StandBy,
                10,
                rewards,
                "이런! 아직 제대로 된 무기도 사용하지 않는군?\n" +
                "무기는 자네의 공격력을 더욱 높여주는 아이템이라네.\n" +
                "낡은 검을 장착하고 오면 내 믿음직한 방어구를 하나 줌세!\n"
                ));

            rewards.Clear();
            rewards.Add(new KeyValuePair<ItemType, string>(ItemType.Potion_HP, "회복 물약"));
            rewards.Add(new KeyValuePair<ItemType, string>(ItemType.Potion_MP, "마나 회복 물약"));
            questList.Add(new LevelupQuest(
                3,
                "더욱 더 강해지기!",
                1,
                QuestState.StandBy,
                20,
                rewards,
                "던전에서 몬스터를 사냥하고 경험을 쌓아보게나.\n" +
                "경험이 쌓일수록 자네는 더욱 더 성장하게 된다네.\n" +
                "레벨을 1 증가시키고 오면 사냥에 도움이 될 아이템을 주겠네.\n"
                ));
        }

        public static QuestManager GetInstance()
        {
            if (null == Instance)
                Instance = new QuestManager();

            return Instance;
        }

        public void PrintQuests()
        {
            foreach (Quest quest in questList)
                quest.PrintShortInfo();
        }
    }
}
