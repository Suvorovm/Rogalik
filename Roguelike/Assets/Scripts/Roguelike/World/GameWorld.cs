using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace Roguelike.World
{
    public class GameWorld : MonoBehaviour
    {
        private static GameWorld _gameWorldInstance;

        private List<GameObject> _gameWorldObjects = new List<GameObject>();

        public event Action OnInitialized;

        private void Awake()
        {
            FetchWorldObjects();
            OnInitialized?.Invoke();
        }

        [NotNull]
        public GameObject RequaireObjectByName(string objectName)
        {
            GameObject go = _gameWorldObjects.FirstOrDefault(o => o.name == objectName);
            if (go == null)
            {
                throw new NullReferenceException($"Объекта с именем {objectName} нет в игровом мире");
            }

            return go;
        }

        [CanBeNull]
        public T GetComponentInWorld<T>()
        {
            T component = _gameWorldObjects.Select(go =>
                {
                    T component = go.GetComponent<T>();
                    return component;
                })
                .FirstOrDefault();
            return component;
        }

        [CanBeNull]
        public GameObject GetParentObjectByName(string objectName)
        {
            return _gameWorldObjects.FirstOrDefault(o => o.name == objectName);
        }

        public void AddGameObject(GameObject gO, [CanBeNull] GameObject container = null,
            bool worldPositionStays = false)
        {
            FetchWorldObjects();
            Transform parentContainer = container == null ? transform : container.transform;
            Instantiate(gO).transform.SetParent(parentContainer, worldPositionStays);
        }

        public void CreateObject(string reqObject, [CanBeNull] string parentObject)
        {
            AddGameObject(RequaireObjectByName(reqObject), GetParentObjectByName(parentObject));
        }

        public void DestroyObjectByName(string objectName)
        {
            FetchWorldObjects();
            Destroy(GetParentObjectByName(objectName));
            Debug.Log("Destroyed");
        }


        public List<GameObject> GameWorldObjects
        {
            get { return _gameWorldObjects; }
        }

        public void FetchWorldObjects()
        {
            _gameWorldObjects = gameObject.GetAllChildren();
            Debug.Log(_gameWorldObjects);
        }


        public static GameWorld GameWorldInstance
        {
            get
            {
                if (_gameWorldInstance == null)
                {
                    _gameWorldInstance = GameApplication.RootAppObject.GetComponentInChildren<GameWorld>();
                }

                return _gameWorldInstance;
            }
        }
    }
}