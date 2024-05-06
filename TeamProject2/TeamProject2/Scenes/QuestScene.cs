using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class QuestScene
    {
        QuestManager questManager = null;

        Player status = null;

        public QuestScene(Player _status)
        {
            questManager = QuestManager.GetInstance();

            if (null == questManager.Status)
                questManager.PlayerSetting(_status);

            status = _status;
        }

        public void ShowQuest()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Quest!!\n");

                questManager.PrintQuests();

                Console.WriteLine();
                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 퀘스트를 선택해주세요.");
                Console.Write(">> ");

                string strInput = Console.ReadLine();
                int inputNum;

                if (int.TryParse(strInput, out inputNum))
                {
                    if ((0 < inputNum) && (questManager.QuestList.Count >= inputNum))
                    {
                        if (QuestState.Finish == questManager.QuestList[inputNum - 1].CurrentState)
                        {
                            Console.WriteLine("이미 완료한 퀘스트입니다..!");

                            Thread.Sleep(1000);
                        }
                        else
                            QuestInfo(inputNum - 1);
                    }    
                    else if (0 == inputNum)
                        return;
                    else
                        Program.InputError();
                }
                else
                    Program.InputError();
            }
        }

        public void QuestInfo(int index)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Quest!!\n");

                questManager.PrintParticularQuest(index);

                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 선택해주세요.");
                Console.Write(">> ");

                string strInput = Console.ReadLine();
                
                if ("1" == strInput)
                {
                    if (QuestState.StandBy == questManager.QuestList[index].CurrentState)
                    {
                        questManager.AcceptQuest(index);

                        Console.WriteLine("\n퀘스트를 수락했습니다!");

                        Thread.Sleep(1000);

                        return;
                    }
                    else if (QuestState.CanFinish == questManager.QuestList[index].CurrentState)
                    {
                        questManager.ClearQuest(index);

                        Console.WriteLine("\n퀘스트를 완료하셨습니다!");

                        Thread.Sleep(1000);

                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n아직 퀘스트를 완료하지 못했습니다..!");

                        Thread.Sleep(1000);
                    }
                }
                else if ("2" == strInput)
                    return;
                else
                    Program.InputError();
            }
        }
    }
}
