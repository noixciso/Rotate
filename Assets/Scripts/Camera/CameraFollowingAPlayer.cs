using UnityEngine;

public class CameraFollowingAPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerMover _playerMover;

    private Vector3 _offset;
    private float _maxDistanceDelta = 0.1f;
    private float _valueAtAcceleration = 20f;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        Vector3 newPosition = new Vector3(position.x, position.y, _offset.z + _target.position.z);

        if (_playerMover.IsExpedited)
        {
            newPosition.z -= _valueAtAcceleration;
            SetPosition(newPosition);
        }
        else
        {
            SetPosition(newPosition);
        }
    }

    private void SetPosition(Vector3 newPosition)
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, _maxDistanceDelta);
    }
}