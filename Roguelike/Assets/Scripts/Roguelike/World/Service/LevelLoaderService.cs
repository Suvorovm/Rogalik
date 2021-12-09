using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Utils;
using Roguelike.World;
using UnityEngine;
using IngameDebugConsole;
using JetBrains.Annotations;

namespace Roguelike.World.Service
{
    public class LevelLoaderService : MonoBehaviour
    {
        private const string LEVEL_PATH = "GameWorld/Levels/Level_";
        private const string CAMERA_NAME = "Main Camera";
        private const string CLONE_STRING = "(Clone)";
        private const string PLAYER_PATH = "GameWorld/2DObject/Player/Player";
        private const string LEVEL_PREFIX = "Level_";
        
        private int _levelNumber = 0;
        private GameObject _player;
        private PlayerProgressService _playerProgressService;
       

        private CameraController _camera;
        [SerializeField] private GameWorld _gameWorld;


        public void LoadNextLevel(int nextLevelnum = 0)
        {
            
            
            _playerProgressService = GameApplication.RequireService<PlayerProgressService>();
            try
            {
                _gameWorld.RequaireObjectByName("Player");
            } catch(NullReferenceException o)
            {
                _player = ResourseLoadService.GetResource<GameObject>(PLAYER_PATH);
                _gameWorld.AddGameObject(_player);
            }

            _gameWorld.DestroyObjectByName(CurentLevelName);


            if (nextLevelnum == 0)
            {
                _levelNumber++;
                Debug.Log("New level value");
            }
            else
            {
                _levelNumber = nextLevelnum;
                Debug.Log("New level value");
            }

            string nextLevelPath = LEVEL_PATH + _levelNumber;
            _gameWorld.AddGameObject(ResourseLoadService.GetResource<GameObject>(nextLevelPath));
            _gameWorld.Init();
            _camera = _gameWorld.RequaireObjectByName(CAMERA_NAME).GetComponent<CameraController>(); 
            _camera.Init();
            _playerProgressService.NextLevel(_levelNumber);
        }

        public string CurentLevelName
        {
            get { return LEVEL_PREFIX + _levelNumber + CLONE_STRING; }
        }
    }
}