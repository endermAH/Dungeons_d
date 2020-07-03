using UnityEngine;

namespace Player
{
  public class Movement : MonoBehaviour
  {
    public new Camera camera;
    private Rigidbody2D _body;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private Transform _transform;

    private float _horizontal;
    private float _vertical;
    private const float MoveLimiter = 0.7f;

    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start () {
      _body = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
      _renderer = GetComponent<SpriteRenderer>();
      _transform = GetComponent<Transform>();
    }

    private void Update() {
      _horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
      _vertical = Input.GetAxisRaw("Vertical"); // -1 is down
      AnimationUpdate();
    }

    private void FixedUpdate() {
      if (_horizontal != 0 && _vertical != 0) {
        _horizontal *= MoveLimiter;
        _vertical *= MoveLimiter;
      }
      AnimationFixedUpdate();
      _body.velocity = new Vector2(_horizontal , _vertical);
    }

    private void AnimationUpdate()
    {
      var mouseX = Input.mousePosition.x;
      var selfX = _transform.position.x * 100;
      var cameraX = camera.transform.position.x * 100;
      float cameraWidth = camera.pixelWidth;
      var absoluteMouseX = cameraX - (cameraWidth / 2) + mouseX;
      if (absoluteMouseX < selfX){
        _renderer.flipX = true;
      }
      if (absoluteMouseX > selfX){
        _renderer.flipX = false;
      }
    
      _animator.SetFloat(Speed, Mathf.Abs(_horizontal) + Mathf.Abs(_vertical));
    }

    private void AnimationFixedUpdate() {
      _animator.SetFloat(Speed, Mathf.Abs(_horizontal*_vertical));
    }
  }
}
