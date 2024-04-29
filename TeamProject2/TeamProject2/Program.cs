namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            if (gameManager.Initialize())
                gameManager.Update();
        }
    }
}
