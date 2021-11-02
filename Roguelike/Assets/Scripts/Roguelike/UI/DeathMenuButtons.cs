using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Roguelike.UI
{


    public class DeathMenuButtons : MonoBehaviour
    {
        [SerializeField]
        private Button _restartButton;
        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
}