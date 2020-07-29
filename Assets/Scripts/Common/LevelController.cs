using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Camera levelCamera;
        [SerializeField] private float cameraAnimationDuration;
        [SerializeField] private GameObject playerPanel;
        [SerializeField] private string nextLevel;
        
        private MoveTo _levelCameraMover;
        private MoveTo _playerPanelMover;
        private Movement _playerMovement;
        private void Start()
        {
            InitFields();
            PrepareObjects();
            StartCoroutine(StartCameraAnimation());
        }

        private void InitFields()
        {
            _levelCameraMover = levelCamera.GetComponent<MoveTo>();
            _playerPanelMover = playerPanel.GetComponent<MoveTo>();
            _playerMovement = player.GetComponent<Movement>();
        }

        private IEnumerator StartCameraAnimation()
        {
            var targetPosition = new Vector3(Screen.width/2, Screen.height/2, -15);
            StartCoroutine(_playerPanelMover.MoveToPoint(targetPosition, 0.5f));
            yield return StartCoroutine(_levelCameraMover.MoveToGameObject(player, cameraAnimationDuration));
            levelCamera.transform.parent = player.transform;
            _playerMovement.enabled = true;
        }

        private void PrepareObjects()
        {
            _playerMovement.enabled = false;
        }

        public void GoToNextLevel()
        {
            SceneManager.LoadScene($"Scenes/{ nextLevel }", LoadSceneMode.Single);
        }
    }
}
