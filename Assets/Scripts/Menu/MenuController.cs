using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        private void Start()
        {
            print("Start!");
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
            // print("Go to scene!");
        }
    }
}
