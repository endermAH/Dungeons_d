using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        private float _deltaY;
        public float deltaTime;
        public Canvas canvas;
        public GameObject gameName;
        private Vector3 _startPosition;
        private SineMovement _sine;
        private bool _gameStarted;

        private void Start()
        {
            _deltaY = Screen.height;
            _sine = gameName.GetComponent<SineMovement>();
            print("Start!");
            StartMovement();
        }

        public void StartGame()
        {
            _sine.StopMovement();
            _gameStarted = true;
            StartMovement();
            // print("Go to scene!");
        }
        
        private void StartMovement()
        {
            _startPosition = transform.position;
            var end = new Vector3(_startPosition.x, _startPosition.y-_deltaY, _startPosition.z);
            StartCoroutine(MoveFromTo(_startPosition, end, deltaTime));
        }
        private IEnumerator MoveFromTo(Vector3 startPoint, Vector3 endPoint, float duration)
        {
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                transform.position = Vector3.Lerp(startPoint, endPoint, timeElapsed / duration);
                timeElapsed += Time.deltaTime;

                yield return null;
            }

            transform.position = endPoint;
            OnMovementEnd();
        }

        private void OnMovementEnd()
        {
            if (!_gameStarted) _sine.StartMovement();
            else SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
        }
    }
}
