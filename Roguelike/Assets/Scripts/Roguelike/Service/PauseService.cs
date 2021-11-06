using UnityEngine;

namespace Roguelike.Service
{
    public class PauseService : MonoBehaviour
    {
        private bool _pause;
        private float _timeScaleBeforePause;

        public void ChangeGameTimeScale()
        {
            if (_pause) {
                UnPauseGame();
            } else {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            _pause = true;
            _timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0;
        }

        private void UnPauseGame()
        {
            _pause = false;
            Time.timeScale = _timeScaleBeforePause;
        }
    }
}