using Core.UI;
using Roguelike.World.UI;
using UnityEngine;

namespace Core.Boot
{
    public class BootStrapService : MonoBehaviour
    {
        private UIService _uiService;
        private void Start()
        {
            _uiService = GameApplication.RequireService<UIService>();
            _uiService.Init();
            LoadGameScreen();
        }

        private void LoadGameScreen()
        {
            _uiService.ShowScreen<GameScreen>(GameScreen.SCREEN_PATH);
        }
    }
}