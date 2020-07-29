using System;
using System.Collections;
using Common;
using Player;
using UnityEngine;
using static Common.LineOfSight;

namespace Enemy
{
    public class SimpleEnemyAI : MonoBehaviour
    {
        private LineOfSight _lineOfSight;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Start()
        {
            _lineOfSight = GetComponent<LineOfSight>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            var player = GetNearestPlayer();
            if (player)
            {
                var direction = player.transform.position - transform.position;
                if (!_animator.GetBool(Hit)) _rigidbody2D.velocity = direction.normalized * 2;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        
            var speed = Mathf.Abs(_rigidbody2D.velocity.x) + Mathf.Abs(_rigidbody2D.velocity.y);
            _animator.SetFloat(Speed, speed);
        }
        
        private GameObject GetNearestPlayer()
        {
            var minDistance = Mathf.Infinity;
            GameObject nearestPlayer = null;
            foreach (var player in _lineOfSight.ObjectInVision)
            {
                var distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer < minDistance)
                {
                    minDistance = distanceToPlayer;
                    nearestPlayer = player;
                }
            }
        
            return nearestPlayer;
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!_animator.GetBool(Hit))
                {
                    var player = other.gameObject;
                    StartCoroutine(HitPlayer(player));
                }
            }
        }
        
        private IEnumerator HitPlayer(GameObject player)
        {
            player.GetComponent<Health>().Damage(20); 
            _animator.SetBool(Hit, true);
            yield return new WaitForSeconds(0.3f); 
            _animator.SetBool(Hit, false);
        }
    }
}
