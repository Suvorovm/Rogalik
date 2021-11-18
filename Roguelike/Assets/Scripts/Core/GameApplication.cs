using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class GameApplication
    {
        private const string MAIN_OBJECT_NAME = "GameApplication";
        private static GameObject _rootApplicationObject;

        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static T RequireService<T>()
        {

            T component = RootAppObject.GetComponent<T>();
            if (component == null) {
                throw new ArgumentException("There is no component " + typeof(T));
            }
            return component;
        }

        public static GameObject RootAppObject
        {
            get
            {
                if (_rootApplicationObject == null) {
                    _rootApplicationObject = GameObject.Find(MAIN_OBJECT_NAME);
                }

                return _rootApplicationObject;
            }
        }
    }
}