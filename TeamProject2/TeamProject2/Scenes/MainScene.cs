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

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 0, 4))
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
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("3. 인벤토리");
            Console.WriteLine("4. 상점\n");
            Console.WriteLine("0. 게임 종료\n");
        }
    }
}
