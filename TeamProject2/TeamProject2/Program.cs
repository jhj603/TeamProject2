namespace TeamProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();        // GameManager 객체 생성

            gameManager.ShowMainScene();        // GameManager의 ShowMainScene() 함수 수행
        }
    }
}
