using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class TestDialog : MonoBehaviour
    {
        [SerializeField]
        private Button _attackButton;
        [SerializeField]
        private Button _suckButton;

        private void Awake()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick); 
            _suckButton.onClick.AddListener(OnSuckButtonClick); 
        }

        private void OnSuckButtonClick()
        {
            Debug.LogWarning("Suck");
        }

        private void OnAttackButtonClick()
        {
            Debug.LogWarning("Attacked");
        }
        
    }
}