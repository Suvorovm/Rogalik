using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Roguelike.UIService
{
    public class UIService : MonoBehaviour
    {
        private List<GameObject> _gameUIObjects;
        
        
                private void Awake()
                {
                    FetchUIObjects();
                }
        
                [NotNull]
                public GameObject RequaireObjectUIByName(string objectName)
                {
                    GameObject go = _gameUIObjects.FirstOrDefault(o => o.name == objectName);
                    if (go == null)
                    {
                        throw new NullReferenceException($"Объекта с именем {objectName} нет в интерфейсе");
                    }
        
                    return go;
                }
        
                [CanBeNull]
                public GameObject GetParentObjectUIByName(string objectName)
                {
                    return _gameUIObjects.FirstOrDefault(o => o.name == objectName);
                }
        
                public void AddGameObjectUI(GameObject gO, [CanBeNull] GameObject container = null,
                    bool worldPositionStays = false)
                {
                    FetchUIObjects();
                    Transform parentContainer = container == null ? transform : container.transform;
                    Instantiate(gO).transform.SetParent(parentContainer, worldPositionStays);
                }
        
                public void CreateObject(string reqObject, [CanBeNull] string parentObject)
                {
                    AddGameObjectUI(RequaireObjectUIByName(reqObject), GetParentObjectUIByName(parentObject));
                }
        
                public void DestroyObject(string objectName)
                {
                    FetchUIObjects();
                    Destroy(GetParentObjectUIByName(objectName));
                    Debug.Log("Destroyed");
                }
        
                public List<GameObject> GameUIObjects
                {
                    get { return _gameUIObjects; }
                }
        
                public void FetchUIObjects()
                {
                    _gameUIObjects = gameObject.GetComponentsInChildren<Transform>(true).ToList().Select(t => t.gameObject)
                        .ToList();
                    Debug.Log(_gameUIObjects);
                }
        // написать тоже самое, что и GameWorld
    }
}