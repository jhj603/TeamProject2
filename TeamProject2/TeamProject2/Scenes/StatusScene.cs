using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TeamProject2
{
    internal class StatusScene : Scene
    {
        public override bool Initialize(Player playerInstance)
        {
            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 0, 0))
            {
                case 0:
                    return SceneType.Main;
                default:
                    return SceneType.NoChange;
            }
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            player.PrintStatus();

            Console.WriteLine();
        }
    }
}
