using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.World.UI.Components
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _healthBar;

        public void UpdateBar(float health)
        {
            _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, health, 2f); //должно быть плавно, но из-за дельта тайма не пашет
            ChangeColor(health);
        }

        private void ChangeColor(float health)
        {
            _healthBar.color = Color.Lerp(Color.red, Color.green, (health));
        }
    }
}