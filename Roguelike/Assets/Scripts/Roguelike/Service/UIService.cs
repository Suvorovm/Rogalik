using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Roguelike.UI;

namespace Roguelike.Service
{
    public class UIService : MonoBehaviour
    {
        public void CreatePrefabObject( GameObject reqObject,[CanBeNull]string parentObject)
        {
            AddGameObject(reqObject, GetParentObjectByName(parentObject));
        }
        public void AddGameObject(GameObject gameObject,[CanBeNull] GameObject container = null, bool worldPositionStays = false)
        {
            Transform parentContainer = container == null ? transform : container.transform;
            Instantiate(gameObject).transform.SetParent(parentContainer,worldPositionStays);
        }
        [CanBeNull]
        public GameObject GetParentObjectByName(string objectName)
        {
            return GetSceneObjects().FirstOrDefault(o => o.name == objectName);
        }
        public GameObject GetReqObjectByName(string objectName)
        {
            return GetSceneObjects().FirstOrDefault(o => o.name == objectName);
        }
        
        public List<GameObject> GetSceneObjects()
        {
            return gameObject.GetComponentsInChildren<Transform>(true).ToList().Select(t => t.gameObject).ToList();
        }
    }
}