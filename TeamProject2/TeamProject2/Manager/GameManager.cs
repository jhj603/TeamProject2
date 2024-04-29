using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class GameManager
    {
        Player? player; // Player player = null;

        Scene? scene;

        Dictionary<SceneType, Scene>? sceneDict;

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
                            if (!sceneDict.ContainsKey(currentScene))
                                sceneDict.Add(currentScene, scene);

                            if (sceneDict.ContainsKey(changeScene))
                                scene = sceneDict[changeScene];
                            else
                                scene = new MainScene();

                            if (!scene.Initialize(player))
                                return;
                            break;
                        case SceneType.Battle:
                            break;
                    }
                }
            }
        }
    }
}
