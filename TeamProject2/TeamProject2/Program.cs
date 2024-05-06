namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();        // GameManager 객체 생성

            gameManager.StartScene();
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
    }
}
