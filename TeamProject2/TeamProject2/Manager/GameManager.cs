using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class GameManager
    {
        Player? player = null; 
        Scene? scene = null;

        Dictionary<SceneType, Scene>? sceneDict = null;

        SceneType currentScene = SceneType.Start;
        SceneType changeScene = SceneType.Create;

        public bool Initialize()        // 객체의 초기화 담당 함수
        {
            if (null == player)
                player = new Player();

            if (null == scene)
            {
                scene = new CreateScene();

                if (!scene.Initialize(player))
                {
                    Console.WriteLine("에러 발생 : 플레이어 세팅");
                    return false;
                }

                currentScene = changeScene;
            }

            sceneDict = new Dictionary<SceneType, Scene>();

            return true;
        }

        public void Update()
        {
            while (true)
            {
                changeScene = scene.Update();

                if (SceneType.NoChange != changeScene)
                {
                    switch (changeScene)
                    {
                        case SceneType.Main:
                            if (!ChangeScene())
                            {
                                Console.WriteLine("씬 변경 실패!");
                                return;
                            }
                            break;
                        case SceneType.Status:
                            if (!ChangeScene())
                            {
                                Console.WriteLine("씬 변경 실패!");
                                return;
                            }
                            break;
                        case SceneType.Battle:
                            if (!ChangeScene())
                            {
                                Console.WriteLine("씬 변경 실패!");
                                return;
                            }
                            break;
                        case SceneType.End:
                            return;
                    }
                }
            }
        }

        bool ChangeScene()
        {
            if (!sceneDict.ContainsKey(currentScene))
                sceneDict.Add(currentScene, scene);

            if (sceneDict.ContainsKey(changeScene))
                scene = sceneDict[changeScene];
            else
            {
                switch (changeScene)
                {
                    case SceneType.Main:
                        scene = new MainScene();
                        break;
                    case SceneType.Status:
                        scene = new StatusScene();
                        break;
                    case SceneType.Battle:
                        scene = new BattleScene();
                        break;
                }               
            }

            currentScene = changeScene;

            if (!scene.Initialize(player))
                return false;

            return true;
        }
    }
}
