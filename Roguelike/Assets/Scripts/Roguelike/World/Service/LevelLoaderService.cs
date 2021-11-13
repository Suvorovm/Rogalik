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
        private static int s_levelNum = 0;
        private static string curentLevel = "Level_" + s_levelNum + CLONE_STRING;

        [SerializeField] private GameWorld _gameWorld;

        private void Awake()
        {
            DebugLogConsole.AddCommand<int>("nextLevel", "Загржает следующий уровень", LoadNextLevel);
        }


        public void LoadNextLevel(int nextLevelnum = 0)
        {
            curentLevel = "Level_" + s_levelNum + CLONE_STRING;

            _gameWorld.DestroyObject(curentLevel);
            Debug.Log("Destroyed");


            if (nextLevelnum == 0)
            {
                s_levelNum++;
                Debug.Log("New level value");
            }
            else
            {
                s_levelNum = nextLevelnum;
                Debug.Log("New level value");
            }

            string nextLevelPath = LEVEL_PATH + s_levelNum;
            _gameWorld.AddGameObject(ResourseLoadService.GetResource<GameObject>(nextLevelPath));
        }
    }
}