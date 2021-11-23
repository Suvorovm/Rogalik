using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Utils
{
    public static class GameObjectExtensions
    {
        [CanBeNull]
        public static GameObject GetChildByName(this GameObject gameObject, string name)
        {
            List<GameObject> allChild = new List<GameObject>();
            foreach (Transform childTransform in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                allChild.Add(childTransform.gameObject);
            }

            return allChild.FirstOrDefault(g => g.name.Equals(name));
        }

        public static void RemoveAllChild(this GameObject gameObject)
        {
            List<GameObject> allChild = new List<GameObject>();
            foreach (Transform childTransform in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                if (gameObject != childTransform.gameObject)
                {
                    allChild.Add(childTransform.gameObject);
                }
            }

            for (var i = 0; i < allChild.Count; i++)
            {
                Object.Destroy(allChild[i]);
            }
        }

        public static T GetOrCreateComponent<T>(this GameObject gameObject)
            where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                return gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}