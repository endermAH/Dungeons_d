using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody2D body;
  Animator animator;
  new SpriteRenderer renderer;

  float horizontal;
  float vertical;
  float moveLimiter = 0.7f;

  public float runSpeed = 1.0f;
  private static readonly int Speed = Animator.StringToHash("Speed");

  private void Start () {
    body = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    renderer = GetComponent<SpriteRenderer>();
  }

  private void Update() {
    horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
    vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    this.AnimationUpdate();
  }

  private void FixedUpdate() {
    if (horizontal != 0 && vertical != 0) {
      horizontal *= moveLimiter;
      vertical *= moveLimiter;
    }
    this.AnimationFixedUpdate();
    body.velocity = new Vector2(horizontal , vertical);
  }

  private void AnimationUpdate() {
    if (horizontal < 0){
      renderer.flipX = true;
    }
    if (horizontal > 0){
      renderer.flipX = false;
    }
    
    animator.SetFloat(Speed, Mathf.Abs(horizontal) + Mathf.Abs(vertical));
  }

  private void AnimationFixedUpdate() {
    animator.SetFloat(Speed, Mathf.Abs(horizontal*vertical));
  }
}
