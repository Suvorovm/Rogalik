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
        
        public void CreatePrefabObject( string reqObjectPath,[CanBeNull]string parentObject)
        {
            AddGameObject(GetPrefabFromResources(reqObjectPath), GetParentObjectByName(parentObject));
        }

        public void CreateObject(string reqObject, [CanBeNull] string parentObject)
        {
            AddGameObject(GetReqObjectByName(reqObject),GetParentObjectByName(parentObject));
        }
        // Создаёт объект.
        public void AddGameObject(GameObject gameObject,[CanBeNull] GameObject container = null, bool worldPositionStays = false)
        {
            Transform parentContainer = container == null ? transform : container.transform;
            Instantiate(gameObject).transform.SetParent(parentContainer,worldPositionStays);
        }
        
        // Находит родителя среди объектов на сцене.
        [CanBeNull]
        public GameObject GetParentObjectByName(string objectName)
        {
            return GetSceneObjects().FirstOrDefault(o => o.name == objectName);
        }
        
        //Находит нужный объект среди объектов на сцене.
        public GameObject GetReqObjectByName(string objectName)
        {
            return GetSceneObjects().FirstOrDefault(o => o.name == objectName);
        }
        
        //Возвращает лист всех объектов на сцене
        public List<GameObject> GetSceneObjects()
        {
            return gameObject.GetComponentsInChildren<Transform>(true).ToList().Select(t => t.gameObject).ToList();
        }
        
        //Загружает префаб по заданному пути
        public GameObject GetPrefabFromResources(string prefabPath)
        {
            return Resources.Load<GameObject>(prefabPath);
        }
    }
}