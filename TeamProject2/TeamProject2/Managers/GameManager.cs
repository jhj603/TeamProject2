using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class GameManager
    {
        Player status = null;               // 플레이어 객체
        BattleScene battleScene = null;     // 배틀씬 객체

        public void ShowMainScene()
        {
            Console.Clear();

            if(status == null)  // status == null이면
            {
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                Console.Write(">> ");

                string nameInput = Console.ReadLine();

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("원하는 직업을 선택해주세요.\n");
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 마법사");
                    Console.WriteLine("3. 도적");
                    Console.WriteLine("4. 궁수");
                    Console.WriteLine("5. ?????\n");
                    Console.Write(">> ");

                    Random random = new Random();

                    string jobInput = Console.ReadLine();
                    int jobNumInput;

                    if (int.TryParse(jobInput, out jobNumInput))
                    {
                        if (jobNumInput == 1)
                        {
                            status = new Player(10, 100, 5, 1, nameInput, "전사", 1500);    // Player 객체 생성
                            break;
                        }
                        else if (jobNumInput == 2)
                        {
                            status = new Player(13, 90, 5, 1, nameInput, "마법사", 1500);
                            break;
                        }
                        else if (jobNumInput == 3)
                        {
                            status = new Player(15, 85, 5, 1, nameInput, "도적", 1500);
                            break;
                        }
                        else if (jobNumInput == 4)
                        {
                            status = new Player(18, 80, 5, 1, nameInput, "궁수", 1500);
                            break;
                        }
                        else if (jobNumInput == 5)
                        {
                            status = new Player(random.Next(10, 21), random.Next(80,101), 5, 1, nameInput, "?????", random.Next(0, 10001));
                            break;
                        }
                        else
                        {
                            Program.InputError();
                        }
                    }
                    else
                    {
                        Program.InputError();
                    }
                }
            }

            while (true)    // 무한 반복
            {
                // 게임 시작 화면 출력
                Console.Clear();

                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

                Console.Write("1. ");
                Program.ColorYellow("상태 보기");
                Console.Write("2. ");
                Program.ColorDarkRed("전투 시작\n\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string input = Console.ReadLine();  // 입력

                switch(input)
                {
                    case "1":   // 1. 상태 보기 입력
                        ShowPlayerStatus();    // ShowPlayerStatus() 호출
                        break;
                    case "2":   // 2. 전투 시작 입력
                        GoDungeon();   // GoDungeon() 호출
                        break;
                    default:    // 1, 2 제외, 문자 입력 숫자 입력
                        Program.InputError(); // "잘못된 입력입니다." 출력
                        break;
                }
            }
        }

        public void ShowPlayerStatus()
        {
            while (true)                                               // 무한 반복
            {
                Console.Clear();

                Program.ColorYellow("상태 보기");                      // 상태 보기 화면("캐릭터의 정보가 표시됩니다." 까지) 출력
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                Console.WriteLine("=====================================");
                status.ShowStatus();                                   // Player.ShowStatus() 호출
                Console.WriteLine("=====================================");

                Console.WriteLine("\n0. 나가기\n");                    // 상태 보기 화면(나머지) 출력
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();                     // 입력
                int num;

                if (int.TryParse(input, out num))                      
                {
                    if (num == 0)                                      // 0. 입력
                    {
                        return;                                        // ShowMainScene()으로 돌아가기
                    }
                    else                                               // 0 제외 숫자 입력
                    {
                        Console.WriteLine("잘못된 입력입니다.");       // "잘못된 입력입니다." 출력
                        Thread.Sleep(1000);
                    }
                }
                else                                                   // 문자 입력
                {
                    Console.WriteLine("잘못된 입력입니다.");           // "잘못된 입력입니다." 출력
                    Thread.Sleep(1000);
                }
            }   
        }

        public void GoDungeon()
        {
            if (battleScene == null) // Battle == null이면
                battleScene = new BattleScene(status); // Battle 객체 생성

            if (battleScene.MonsterSpawn() == false) // Battle.MonsterSpawn() 수행이 실패하면
            {
                // 에러 경고 문자열 출력 후 ShowMainScene()으로 돌아가기
                Console.WriteLine("error");
                ShowMainScene();
            }

            else// Battle.MonsterSpawn() 수행이 성공하면
            {
                // Battle.ShowBattle() 수행
                battleScene.ShowBattle();
            }

        }
    }
}
