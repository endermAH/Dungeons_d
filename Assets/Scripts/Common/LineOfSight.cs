using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Common
{
    public class LineOfSight : MonoBehaviour
    {
        [SerializeField] private float sightRange;
        [SerializeField] private string targetTag;
        [SerializeField] private LayerMask layerMask;

        public readonly List<GameObject> ObjectInVision = new List<GameObject>(); 

        private GameObject[] _targets;
        
        private void Start () 
        {
            _targets = GameObject.FindGameObjectsWithTag(targetTag);
        }

        private void Update()
        {
            foreach (var target in _targets)
            {    
                ObjectInVision.Clear();
                if (IsVisibleObject(target))
                {
                    ObjectInVision.Add(target);
                }
            }
        }
    
        private bool IsVisibleObject(GameObject target)
        {
            var result = false;
            
            Vector2 targetPosition = target.transform.position;
            Vector2 selfPosition = transform.position;
            Vector2 direction = targetPosition - selfPosition;

            if (Vector2.Distance(selfPosition, targetPosition) > sightRange) return false;
            
            var hit = Physics2D.Raycast(selfPosition, direction, layerMask);
            if (hit)     
            {
                if (hit.collider.gameObject == target)
                {
                    result = true;
                    Debug.DrawLine(selfPosition, hit.point, Color.green);
                }
                else
                {
                    Debug.DrawLine(selfPosition, hit.point, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(selfPosition, direction, Color.red);
            }
            return result;
        }
    }
}
