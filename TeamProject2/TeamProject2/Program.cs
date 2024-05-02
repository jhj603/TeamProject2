namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = GameManager.GetInstance();

            if (gameManager.Initialize())
                gameManager.Update();
        }
    }
}
