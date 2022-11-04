using UnityEngine;

public class AccelerationVFX : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private ParticleSystem _vfx;

    private void OnEnable()
    {
        _playerMover.Acceleration += OnControlVFX;
    }

    private void OnDisable()
    {
        _playerMover.Acceleration -= OnControlVFX;
    }

    private void FixedUpdate()
    {
        float xRotation = -90;
        float yRotation = 0;
        float zRotation = 0;

        _vfx.gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }

    private void OnControlVFX(bool isExpedited)
    {
        if (isExpedited)
        {
            _vfx.Play();
        }
        else
        {
            _vfx.Stop();
        }
    }
}