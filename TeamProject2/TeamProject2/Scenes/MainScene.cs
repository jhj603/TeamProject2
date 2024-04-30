using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class MainScene : Scene
    {
        public override bool Initialize(Player playerInstance)
        {
            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 1, 2))
            {
                case 1:
                    break;
                case 2:
                    return SceneType.Battle;
                default:
                    break;
            }

            return SceneType.NoChange;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작\n");
        }
    }
}
