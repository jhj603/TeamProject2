using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class CreateScene : Scene
    {
        string? nameInput;

        PlayerJob inputJob;

        public override bool Initialize(Player playerInstance)
        {
            return base.Initialize(playerInstance);
        }

        public override SceneType Update()
        {
            PrintDialogue();

            if (null == nameInput)
                nameInput = Console.ReadLine();
            else
                Console.WriteLine(nameInput);

            PrintJobList();

            inputJob = (PlayerJob)MenuChoice("원하시는 직업을 설정해주세요.", (int)PlayerJob.Warrior, (int)PlayerJob.Archer);

            switch (inputJob)
            {
                case PlayerJob.Warrior:
                    if (player.Initialize(1, nameInput, inputJob, 8, 10, 100, 1500, 50))
                        return SceneType.Main;
                    else
                        return SceneType.End;
                case PlayerJob.Magician:
                    if (player.Initialize(1, nameInput, inputJob, 15, 3, 100, 1500, 50))
                        return SceneType.Main;
                    else
                        return SceneType.End;
                case PlayerJob.Archer:
                    if (player.Initialize(1, nameInput, inputJob, 10, 5, 100, 1500, 50))
                        return SceneType.Main;
                    else
                        return SceneType.End;
                default:
                    return SceneType.NoChange;
            }
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
        }

        void PrintJobList()
        {
            Console.WriteLine("\n[직업 목록]\n");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수\n");
        }
    }
}
