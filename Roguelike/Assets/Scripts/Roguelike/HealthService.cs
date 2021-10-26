using UnityEngine;

namespace Roguelike
{
    public class HealthService : MonoBehaviour
    {
        private int _health = 100;

        public void IncreaseHealth(int health)
        {
            _health += health;
            /*Update UI*/
        }

        public void DecreaseHealth(int health)
        {
            _health -= health;
            /*Update UI*/

        }

    }
}