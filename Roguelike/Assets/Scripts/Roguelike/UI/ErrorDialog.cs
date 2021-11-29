using Core;
using Core.UI;
using Core.UI.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class ErrorDialog : MonoBehaviour, IDialog
    {
        public const string DIALOG_PATH = "UI/Game/Dialog/Error/pfErrorDialog";

        [SerializeField]
        private Button _exitButton;

        private UIService _uiService;
        public void Configure(IDialogModel dialogModel)
        {
            _exitButton.onClick.AddListener(OnExitButtonClick);
            _uiService = GameApplication.RequireService<UIService>();
        }

        private void OnExitButtonClick()
        {
            _uiService.HideDialog(gameObject);
        }
    }
}