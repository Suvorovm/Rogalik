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
        private const string CLONE_STRING = "(Clone)";
        private int _levelNumber = 0;
        private const string LEVEL_PREFIX = "Level_";


        [SerializeField] private GameWorld _gameWorld;


        public void LoadNextLevel(int nextLevelnum = 0)
        {
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
        }

        public string CurentLevelName
        {
            get { return LEVEL_PREFIX + _levelNumber + CLONE_STRING; }
        }
    }
}