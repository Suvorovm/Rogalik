using Core;
using Core.UI;
using Core.UI.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class AlertDialog : MonoBehaviour, IDialog
    {
        public const string DIALOG_PATH = "UI/Game/Dialog/Alert/pfAlertDialog";

        [SerializeField]
        private Button _exitButton;
        private UIService _uiService;
        public void Configure(IDialogModel dialogModel)
        {
            _uiService = GameApplication.RequireService<UIService>();
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnExitButtonClick()
        {
            _uiService.HideDialog(gameObject);
        }
    }
}