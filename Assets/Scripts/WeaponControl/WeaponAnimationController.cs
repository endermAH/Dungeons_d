using System.Collections;
using UnityEngine;
using Lang = Languages.Languages;

namespace WeaponControl
{
    public class WeaponAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private new Camera camera;
    
        private Transform _transform;
        private Weapon _weapon;
        private Animator _animator;
    
        private bool _onCooldown = false;
        private Vector3 _handPosition;

        private void Start()
        {
            _weapon = Weapon.RegularSword;
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
            _handPosition = _weapon.HandPosition;
            print($"{Lang.RegularSword.Name}: {Lang.RegularSword.Description}");
        }

        private void Update()
        {
            KeepPosition();
            if (Input.GetMouseButtonUp(0))
            {
                if (!_onCooldown) StartCoroutine(AnimateWeapon());
            }
        }

        private void KeepPosition()
        {
            var mouseX = Input.mousePosition.x;
            var selfX = _transform.position.x * 100;
            var cameraX = camera.transform.position.x * 100;
            float cameraWidth = camera.pixelWidth;
            var workHandPosition = _handPosition;
            var absoluteMouseX = cameraX - (cameraWidth / 2) + mouseX;
            if (absoluteMouseX < selfX) workHandPosition.x = _handPosition.x * -1;
            var newPosition = (workHandPosition / 100) + player.transform.position;
            _transform.position = newPosition;
        }

        private IEnumerator AnimateWeapon()
        {
            _animator.Play("Attack");
            _onCooldown = true;
            
            yield return new WaitForSeconds(0.5f); //Wait few seconds to animation completes
            yield return new WaitForSeconds(_weapon.Stats.AttackCooldown);

            _onCooldown = false;
        
        } 
    }
}
