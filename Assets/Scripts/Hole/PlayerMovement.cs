using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick _joystick;
    [SerializeField]
    private GameObject _player;

    #region movement
    private Rigidbody _rigidbody;
    private const float _speed = 25f;
    private const float _maxSpeed = 7f;

    private const float xLimit = 7f;
    private const float zMax = 10f;
    private const float zMin = -6f;

    private Vector3 _movementDirection;
    private Vector3 _currentVelocity;

    private bool _isMoving = false;
    #endregion

    private void Awake()
    {
        _rigidbody = _player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentVelocity = _rigidbody.velocity;
    }
    private void FixedUpdate()
    {
        MoveHoleFollowTheDirection();
    }

    private void MoveHoleFollowTheDirection()
    {
        _movementDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        HoleMoveLimitor();
        if (_movementDirection != Vector3.zero)
        {
            _isMoving = true;
            if (_rigidbody.velocity.magnitude < _maxSpeed)
            {
                _rigidbody.AddForce(_movementDirection * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            else
            {
                _rigidbody.velocity = _movementDirection * _maxSpeed;
            }
        }
        else
        {
            if (_isMoving)
            {
                _rigidbody.velocity = new Vector3(0, _currentVelocity.y, 0);
                _isMoving = false;
            }
        }
    }

    private void HoleMoveLimitor()
    {
        if (_player.transform.position.x > xLimit)
        {
            _player.transform.position = new Vector3(xLimit, _player.transform.position.y, _player.transform.position.z);
        }
        if (_player.transform.position.x < -xLimit)
        {
            _player.transform.position = new Vector3(-xLimit, _player.transform.position.y, _player.transform.position.z);
        }
        if (_player.transform.position.z > zMax)
        {
            _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, zMax);
        }
        if (_player.transform.position.z < zMin)
        {
            _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, zMin);
        }
    }

}
