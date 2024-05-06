using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class QuestScene : Scene
    {
        QuestManager questManager = null;

        public override bool Initialize(Player playerInstance)
        {
            questManager = QuestManager.GetInstance();

            if (null == questManager)
                return false;

            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 퀘스트를 선택해주세요.", 0, 5))
            {
                case 0:
                    return SceneType.End;
                case 1:
                    return SceneType.Status;
                case 2:
                    if (CharacterState.Dead == player.CurrentState)
                    {
                        Console.WriteLine("\n죽었습니다..!");

                        Thread.Sleep(1000);

                        return SceneType.NoChange;
                    }
                    return SceneType.Battle;
                case 3:
                    return SceneType.Inventory;
                case 4:
                    return SceneType.Shop;
                case 5:
                    return SceneType.Quest;
                default:
                    break;
            }

            return SceneType.NoChange;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("Quest!!\n");

            questManager.PrintQuests();
            
            Console.WriteLine("\n0. 나가기\n");
        }
    }
}
