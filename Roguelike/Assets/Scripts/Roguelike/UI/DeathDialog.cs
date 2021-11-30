using Core;
using Core.UI;
using Core.UI.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class DeathDialog : MonoBehaviour, IDialog
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        public const string DEATH_MENU_PATH = "UI/Game/Dialog/DeathMenuDialog/pfDeathMenuDialog";

        private void Restart()
        {
            GameApplication.Restart();
        }

        private void GoToMainMenu()
        {
            Debug.Log("Должен перейти в главное меню");
        }

        public void Configure(IDialogModel dialogModel)
        {
            _restartButton.onClick.AddListener(Restart);
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
    }
}