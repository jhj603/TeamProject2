using System.Security.Cryptography.X509Certificates;

namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            gameManager.ShowMainScene();
        }

        public static void InputError()
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(500);
        }
    }
}
