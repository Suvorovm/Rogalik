using Core.UI;
using Roguelike.World.UI;
using UnityEngine;

namespace Core.Boot
{
    public class BootStrapService : MonoBehaviour
    {
        private UIService _uiService;
        private MainMenu _mainMenu;
        private void Start()
        {
            _uiService = GameApplication.RequireService<UIService>();
            _uiService.Init();
            LoadMainMenu();
        }

        public void LoadGameScreen()
        {
            _uiService.ShowScreen<GameScreen>(GameScreen.SCREEN_PATH);
        }

        private void LoadMainMenu()
        {
            _uiService.ShowScreen<MainMenu>(MainMenu.SCREEN_PATH);
        }
        
    }
}