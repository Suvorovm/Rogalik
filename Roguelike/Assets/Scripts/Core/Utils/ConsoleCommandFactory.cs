using Core.UI;
using IngameDebugConsole;
using JetBrains.Annotations;
using Roguelike.Settings.Repository;
using Roguelike.Settings.Service;
using Roguelike.UI;
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

        [ConsoleMethod("damagePlayer", "Наносит урон")]
        [UsedImplicitly]
        public static void DecrHealth(int damage)
        {
            HealthService healthService = GameApplication.RequireService<HealthService>();
            healthService.DecreaseHealth(damage);
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
        
        
        [ConsoleMethod("showAlert", "Showed Alert dialog")]
        [UsedImplicitly]
        public static void ShowAlertDialog()
        {
            UIService uiService = GameApplication.RequireService<UIService>();
            uiService.ShowDialog<AlertDialog>(AlertDialog.DIALOG_PATH);
        }
        
        
        [ConsoleMethod("showError", "Showed Error dialog")]
        [UsedImplicitly]
        public static void ShowErrorDialog()
        {
            UIService uiService = GameApplication.RequireService<UIService>();
            uiService.ShowDialog<ErrorDialog>(ErrorDialog.DIALOG_PATH);
        }
        
        
        [ConsoleMethod("turnOnMusic", "test Game World")]
        [UsedImplicitly]
        public static void TurnOnMusic()
        {
            PlayerSettingsService playerSettingsService = GameApplication.RequireService<PlayerSettingsService>();
            playerSettingsService.TurnOnMusic();
        }
        
        [ConsoleMethod("turnOffMusic", "test Game World")]
        [UsedImplicitly]
        public static void TurnOffMusic()
        {
            PlayerSettingsService playerSettingsService = GameApplication.RequireService<PlayerSettingsService>();
            playerSettingsService.TurnOffMusic();
        }
        
        [ConsoleMethod("isMusicTurnOn", "test Game World")]
        [UsedImplicitly]
        public static void IsMusicTurnOn()
        {
            PlayerSettingsService playerSettingsService = GameApplication.RequireService<PlayerSettingsService>();
            Debug.Log($"PlayerSettingModel.MusicOn = {playerSettingsService.IsMusicOn}");
        }

        [ConsoleMethod("removeSettings", "test Game World")]
        [UsedImplicitly]
        public static void RemoveSettingsRepository()
        {
            PlayerSettingsRepository playerSettingsService = GameApplication.RequireService<PlayerSettingsRepository>();
            playerSettingsService.Clear();
        }
    }
}