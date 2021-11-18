using IngameDebugConsole;
using JetBrains.Annotations;
using Roguelike.World;
using Roguelike.World.Service;
using UnityEngine;

namespace Core.Utils
{
    public class ConsoleCommandFactory : MonoBehaviour
    {
        [ConsoleMethod("sayGay", "Print message")]
        [UsedImplicitly]
        public static void SayGay()
        {
            Debug.LogWarning("You are GAY!!!");
        }

        [ConsoleMethod("testHealth", "Test Game application ")]
        [UsedImplicitly]
        public static void TestGameApplication()
        {
            HealthService healthService = GameApplication.RequireService<HealthService>();
            healthService.DecreaseHealth(20);
            Debug.Log(healthService.ToString());
        }

        [ConsoleMethod("loadLevel", "Загружает уровень")]
        [UsedImplicitly]
        public static void LoadLevelConsole(int levelNum)
        {
            LevelLoaderService levelLoaderService = GameApplication.RequireService<LevelLoaderService>();
            levelLoaderService.LoadNextLevel(levelNum);
        }


        [ConsoleMethod("restart", "Restart")]
        [UsedImplicitly]
        public static void RestartTheGame()
        {
            GameApplication.Restart();
        }

        [ConsoleMethod("testStaticGameWorld", "test Game World")]
        [UsedImplicitly]
        public static void TestGameWorldApi()
        {
            GameWorld gameWorldInstance = GameWorld.GameWorldInstance;
            GameObject testObject = gameWorldInstance.RequaireObjectByName("TestObject");
            Debug.Log($"Is test object null {testObject == null}");
        }
    }
}