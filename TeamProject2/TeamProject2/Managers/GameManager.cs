using System;
using System.Collections.Generic;
using System.Linq;
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
            if(status == null)  // status == null이면
            {
                status = new Player();    // Player 객체 생성
            }

            while (true)    // 무한 반복
            {
                // 게임 시작 화면 출력
                Console.Clear();

                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");
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
            // 무한 반복
                
                // 상태 보기 화면("캐릭터의 정보가 표시됩니다." 까지) 출력

                // Player.ShowStatus() 호출

                // 상태 보기 화면(나머지) 출력

                // 입력

                    // 0. 입력
                        
                        // ShowMainScene()으로 돌아가기

                    // 0 제외 숫자 입력
                        
                        // "잘못된 입력입니다." 출력

                // 문자 입력

                    // "잘못된 입력입니다." 출력
        }

        public void GoDungeon()
        {
            // Battle == null이면
                
                // Battle 객체 생성

            // Battle.MonsterSpawn() 수행이 실패하면

                // 에러 경고 문자열 출력 후 ShowMainScene()으로 돌아가기

            // Battle.MonsterSpawn() 수행이 성공하면

                // Battle.ShowBattle() 수행
        }
    }
}
