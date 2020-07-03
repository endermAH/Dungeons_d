using System.Collections;
using UnityEngine;

namespace WeaponControl
{
    public class WeaponAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private new Camera camera;
    
        private Transform _transform;
        private Weapon _weapon;
    
        private bool _onCooldown = false;
        private bool _onAttack = false;
        private Vector3 _handPosition;
        private float _angleToMouse;

        private Quaternion _targetRotation;
        private Quaternion _fromRotation;
        private Quaternion _toRotation;
        private void Start()
        {
            _weapon = Weapon.RegularSword;
            _transform = GetComponent<Transform>();
            _handPosition = _weapon.HandPosition;
        }

        private void Update()
        {
            KeepPosition();
            if (Input.GetMouseButtonUp(0))
            {
                if (!_onCooldown) StartCoroutine(AnimateWeapon());
                _targetRotation = Quaternion.Euler(0f, 0f, _angleToMouse);
                _fromRotation = Quaternion.Euler(0, 0, _targetRotation.z - 90);
                _toRotation = Quaternion.Euler(0, 0, _targetRotation.z + 90);
                print($"from: {_fromRotation.z}, to: {_toRotation.z}");
            }
        
            KeepRotation();
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
            print("Attack!");
            _onCooldown = true;
            _onAttack = true;
        
            yield return new WaitForSeconds(0.7f);
            _onAttack = false;
            _transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            yield return new WaitForSeconds(_weapon.AttackCooldown);

            print("Cooldown finished");
            _onCooldown = false;
        
        }

        private void KeepRotation()
        {
            var diff = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            _angleToMouse = rotZ - 90;

            if (_onAttack) AttackRotation(_fromRotation, _toRotation);
            else RotateSwordToMouse();
        }
        private void RotateSwordToMouse()
        {
            var singleStep = 500 * Time.deltaTime;
            var targetRotation = Quaternion.Euler(0f, 0f, _angleToMouse);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, singleStep);
        }

        private void AttackRotation(Quaternion fromRotation, Quaternion toRotation)
        {
            var singleStep = 200 * Time.deltaTime;
            _transform.rotation = Quaternion.RotateTowards(fromRotation, toRotation, singleStep);
        }
    }
}
