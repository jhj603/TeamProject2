namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartScene();
        }

        public static void InputError()
        {
            Console.WriteLine("잘못 입력하셨습니다.");
            Thread.Sleep(1000);
        }

        public static void ColorDarkRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ColorYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void StartScene()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("           ______  _____  ____              ");
            Console.WriteLine("           | ___ \\|  _  |/ ___|             ");
            Console.WriteLine("           | |_/ /| |/' / /___              ");
            Console.WriteLine("           | ___ \\|  /| | ___ \\             ");
            Console.WriteLine("           | |_/ /\\ |_/ / \\_/ |             ");
            Console.WriteLine("           \\____/  \\___/\\_____/             ");
            Console.WriteLine("");
            Console.WriteLine("______ _   _ _   _ _____  _____ _____ _   _ ");
            Console.WriteLine("|  _  \\ | | | \\ | |  __ \\|  ___|  _  | \\ | |");
            Console.WriteLine("| | | | | | |  \\| | |  \\/| |__ | | | |  \\| |");
            Console.WriteLine("| | | | | | | . ` | | __ |  __|| | | | . ` |");
            Console.WriteLine("| |/ /| |_| | |\\  | |_\\ \\| |___\\ \\_/ / |\\  |");
            Console.WriteLine("|___/  \\___/\\_| \\_/\\____/\\____/ \\___/\\_| \\_/");
            Console.ResetColor();
            Console.WriteLine("=============================================");
            Console.WriteLine("             PRESS ANY BUTTON");
            Console.WriteLine("=============================================");
            Console.ReadKey();

            GameManager gameManager = new GameManager();        // GameManager 객체 생성

            gameManager.ShowMainScene();        // GameManager의 ShowMainScene() 함수 수행
        }
    }
}
