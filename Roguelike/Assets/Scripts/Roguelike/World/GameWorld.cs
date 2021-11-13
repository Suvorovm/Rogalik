﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Roguelike.World
{
    public class GameWorld : MonoBehaviour
    {
        private List<GameObject> _gameWorldObjects;
        private void Awake()
        {
            _gameWorldObjects = gameObject.GetComponentsInChildren<Transform>(true).ToList().Select(t => t.gameObject).ToList();
        }

        [NotNull]
        public GameObject RequaireObjectByName(string objectName)
        {
            GameObject go = _gameWorldObjects.FirstOrDefault(o => o.name == objectName);
            if (go == null) {
                throw new NullReferenceException($"Объекта с именем {objectName} нет в игровом мире");
            }
            return go;
        }
        
        [CanBeNull]
        public GameObject GetParentObjectByName(string objectName)
        {
            return _gameWorldObjects.FirstOrDefault(o => o.name == objectName);
        }
        
        public void AddGameObject(GameObject gO, [CanBeNull] GameObject container = null, bool worldPositionStays = false)
        {
            Transform parentContainer = container == null ? transform : container.transform;
            Instantiate(gO).transform.SetParent(parentContainer, worldPositionStays);
        }
        
        public void CreateObject(string reqObject, [CanBeNull] string parentObject)
        {
            AddGameObject(RequaireObjectByName(reqObject), GetParentObjectByName(parentObject));
        }
        
        public List<GameObject> GameWorldObjects
        {
            get { return _gameWorldObjects; }
        }
    }
}