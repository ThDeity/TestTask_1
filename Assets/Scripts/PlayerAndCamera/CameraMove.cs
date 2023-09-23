using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _playerVector;
    [SerializeField] private float _speed;
    private Transform _playerPosition, _transform;

    private void Start()
    {
        _playerPosition = FindObjectOfType<PlayerMovement>().transform;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _playerVector = _playerPosition.position;
        _playerVector.z = -10;
        _transform.position = Vector3.Lerp(_transform.position, _playerVector, _speed * Time.deltaTime);
    }
}
