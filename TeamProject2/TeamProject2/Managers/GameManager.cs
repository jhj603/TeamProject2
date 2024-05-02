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
            // status == null이면

            // Player 객체 생성

            // 무한 반복

            // 게임 시작 화면 출력

            // 입력

            // 1. 상태 보기 입력

            // ShowPlayerStatus() 호출

            // 2. 전투 시작 입력

            // GoDungeon() 호출

            // 1, 2 제외 숫자 입력

            // "잘못된 입력입니다." 출력

            // 문자 입력

            // "잘못된 입력입니다." 출력
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
            if (battleScene == null) // Battle == null이면
                battleScene = new BattleScene(); // Battle 객체 생성

            if (battleScene.MonsterSpawn() == false) // Battle.MonsterSpawn() 수행이 실패하면
            {
                // 에러 경고 문자열 출력 후 ShowMainScene()으로 돌아가기
                Console.WriteLine("error");
                return;
            }

            else// Battle.MonsterSpawn() 수행이 성공하면
            {
                // Battle.ShowBattle() 수행
                battleScene.ShowBattle();
            }

        }
    }
}
