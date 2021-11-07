using System;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.World.UI
{
    public class InputController : MonoBehaviour
    {
        public delegate void JoystickEvent(Vector2 directional);

        public static event JoystickEvent OnJoyStickMove;

        public delegate void AttackEvent();

        public static event JoystickEvent OnAttack;
        [SerializeField]
        private VariableJoystick _joystick;
        [SerializeField]
        private Button _attackButton;

        private void Awake()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick);
        }

        private void OnAttackButtonClick()
        {
        }

        private void Update()
        {
            Vector2 joystickDirection = _joystick.Direction;
            if (joystickDirection != Vector2.zero) {
                OnJoyStickMove?.Invoke(joystickDirection);
            }
        }
    }
}