using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _healthBar;


        public void UpdateBar(float health)
        {
            _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, health, 1.2f * Time.deltaTime);
            ChangeColor(health);
        }

        private void ChangeColor(float health)
        {
            _healthBar.color = Color.Lerp(Color.red, Color.green, (health));
        }

    }
}