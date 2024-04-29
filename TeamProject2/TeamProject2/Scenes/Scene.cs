using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum SceneType
    {
        Start,
        Create,
        Main,
        Status,
        Battle,
        NoChange
    }

    internal abstract class Scene
    {
        protected Player? player;

        protected int selectInput = 0;

        public virtual bool Initialize(Player playerInstance)
        {
            if (null == player)
            {
                player = playerInstance;

                return true;
            }

            return false;
        }

        public abstract SceneType Update();

        protected abstract void PrintDialogue();

        protected void PrintInputError()
        {
            Console.WriteLine("\n잘못된 입력입니다!");

            Thread.Sleep(1000);
        }

        protected int MenuChoice(string printText, int min, int max)
        {
            Console.WriteLine(printText);
            Console.Write(">> ");

            if (int.TryParse(Console.ReadLine(), out selectInput))
            {
                if ((min <= selectInput) && (max >= selectInput))
                    return selectInput;
                else
                    PrintInputError();
            }
            else
                PrintInputError();

            return -1;
        }
    }
}
