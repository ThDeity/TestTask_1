using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    private Vector2 _moveInput, _moveVelocity;
    [SerializeField] private Joystick _moveJoystick;

    private void Start() => _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update() => _moveInput = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical);

    private void FixedUpdate()
    {
        _moveVelocity = _moveInput.normalized * _speed;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
