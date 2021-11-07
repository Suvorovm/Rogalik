using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class GameApplication
    {
        private const string MAIN_OBJECT_NAME = "GameApplication";
        private static GameObject _mainObject;

        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static T RequireService<T>()
        {
            if (_mainObject == null) {
                _mainObject = GameObject.Find(MAIN_OBJECT_NAME);
            }
            T component = _mainObject.GetComponent<T>();
            if (component == null) {
                throw new ArgumentException("There is no component " + typeof(T));
            }
            return component;
        }
    }
}