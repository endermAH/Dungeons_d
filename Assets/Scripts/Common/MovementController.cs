using UnityEngine;

namespace Common
{
    public class MovementController : MonoBehaviour
    {
    //     private Rigidbody2D _body;
    //     private Animator _animator;
    //
    //     private int _horizontal;
    //     private int _vertical;
    //     private const float MoveLimiter = 0.7f;
    //
    //     private static readonly int Speed = Animator.StringToHash("Speed");
    //
    //     private void Start () {
    //         _body = GetComponent<Rigidbody2D>();
    //         _animator = GetComponent<Animator>();
    //     }
    //
    //     private void Update()
    //     {
    //         AnimationUpdate();
    //     }
    //
    //     public void UpdateDirection()
    //     {
    //         
    //     }
    //
    //     private void FixedUpdate() {
    //         if (_horizontal != 0 && _vertical != 0) {
    //             _horizontal *= MoveLimiter;
    //             _vertical *= MoveLimiter;
    //         }
    //         AnimationFixedUpdate();
    //         _body.velocity = new Vector2(_horizontal , _vertical);
    //     }
    //
    //     private void AnimationUpdate()
    //     {
    //         _animator.SetFloat(Speed, Mathf.Abs(_horizontal) + Mathf.Abs(_vertical));
    //     }
    //
    //     private void AnimationFixedUpdate() {
    //         _animator.SetFloat(Speed, Mathf.Abs(_horizontal*_vertical));
    //     }
    // }
    }
}
