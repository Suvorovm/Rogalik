using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class DeathMenuButtons : MonoBehaviour
    {
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _mainMenuButton;


        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void Restart()
        {
            GameApplication.Restart();
        }

        private void GoToMainMenu()
        {
            Debug.Log("Должен перейти в главное меню");
        }
    }
}