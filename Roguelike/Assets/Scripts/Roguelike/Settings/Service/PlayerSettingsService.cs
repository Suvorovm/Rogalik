using Core;
using JetBrains.Annotations;
using Roguelike.Settings.Model;
using Roguelike.Settings.Repository;
using UnityEngine;

namespace Roguelike.Settings.Service
{
    public class PlayerSettingsService : MonoBehaviour
    {
        private PlayerSettingsRepository _playerSettingsRepository;
        private SettingsModel _settingsModel;

        private void Awake()
        {
            _playerSettingsRepository = GameApplication.RequireService<PlayerSettingsRepository>();
            _settingsModel = _playerSettingsRepository.Get();
            if (_settingsModel == null)
            {
                CreateSettingsModel();
            }
        }

        [PublicAPI]
        public void TurnOnMusic()
        {
            _settingsModel.MusicIsOn = true;
            _playerSettingsRepository.Save(_settingsModel);
        }
        [PublicAPI]
        public void TurnOffMusic()
        {
            _settingsModel.MusicIsOn = false;
            _playerSettingsRepository.Save(_settingsModel);
        }
        [PublicAPI]
        public void TurnOnSound()
        {
            _settingsModel.SoundIsOn = true;
            _playerSettingsRepository.Save(_settingsModel);
        }

        [PublicAPI]

        public void TurnOffSound()
        {
            _settingsModel.SoundIsOn = false;
            _playerSettingsRepository.Save(_settingsModel);
        }
        private void CreateSettingsModel()
        {
            _settingsModel = new SettingsModel();
            _playerSettingsRepository.Save(_settingsModel);
        }

        public bool IsSoundOn => _settingsModel.SoundIsOn;
        public bool IsMusicOn => _settingsModel.MusicIsOn;
    }
}