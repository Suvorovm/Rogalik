using DG.Tweening;
using Roguelike.World.UI;
using UnityEngine;

namespace Roguelike.World.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const string PLAYER_NAME = "Player";
        [SerializeField]
        private float _speed = 2.5f;
        private Sequence _sequence;
        private bool _facingRight;

        private void OnEnable()
        {
            name = PLAYER_NAME;
            InputController.OnJoyStickMove += Move;
        }

        private void OnDisable()
        {
            InputController.OnJoyStickMove -= Move;
        }

        private void Move(Vector2 directional)
        {
            Vector2 moveVector = directional.normalized;
            float time = moveVector.magnitude / _speed;
            Vector2 position = transform.position;
            Vector3 moveTo = new Vector3(position.x + moveVector.x, position.y + moveVector.y, 0);
            if (directional.x < 0 && _facingRight) {
                Flip();
            } else if (directional.x > 0 && !_facingRight) {
                Flip();
            }
            _sequence.Append(transform.DOMove(moveTo, time));
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
        }
    }
}