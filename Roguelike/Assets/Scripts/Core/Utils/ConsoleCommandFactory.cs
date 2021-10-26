using IngameDebugConsole;
using JetBrains.Annotations;
using Roguelike;
using Roguelike.Service;
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
            healthService.DecreaseHealth(10);
            Debug.Log(healthService.ToString());
        }
        
        
        
        [ConsoleMethod("restart", "Restart")]
        [UsedImplicitly]
        public static void RestartTheGame()
        {
            GameApplication.Restart();
        }
    }
}