using Roguelike.World.UI;
using UnityEngine;

namespace Roguelike.World.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const string PLAYER_NAME = "Player";
        [SerializeField]
        private float _speed = 2.5f;

        [SerializeField] private GameObject _attackPoint;
        private bool _facingRight;
        private Rigidbody2D _rigidbody2D;

        private void OnEnable()
        {
            name = PLAYER_NAME;
            InputController.OnJoyStickMove += Move;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            InputController.OnJoyStickMove -= Move;
        }

        private void Move(Vector2 directional)
        {
            if (directional.x < 0 && _facingRight) {
                Flip();
            } else if (directional.x > 0 && !_facingRight) {
                Flip();
            }
            _rigidbody2D.MovePosition(_rigidbody2D.position  + (directional  * _speed * Time.fixedDeltaTime));
        }

        private void Flip()
        {
            if (Time.timeScale == 0) {
                return;
            }
            _facingRight = !_facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
            _attackPoint.transform.Rotate(0,180,0);
        }
    }
}