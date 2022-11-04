using UnityEngine;
using UnityEngine.Events;

enum State
{
    None,
    Dirty,
    Clean
}

public class EntranceToArchway : MonoBehaviour
{
    private State _state = State.None;
    private const int LayerZone = 6;
    private const int LayerPlayerCubes = 3;

    public event UnityAction CleanMovement;
    public event UnityAction DirtyMovement;
    public event UnityAction CollisionWithCube;
    
    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerZone,LayerPlayerCubes);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Cube cube))
        {
            _state = State.Dirty;
            cube.SetUpRigidbodyAtContact();
            CollisionWithCube?.Invoke();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (_state == State.Dirty && other.collider.GetComponent<PointZone>())
        {
            DirtyMovement?.Invoke();
            _state = State.None;
        }
        else if (_state == State.None || _state == State.Clean)
        {
            if (other.collider.GetComponent<PointZone>())
            {
                CleanMovement?.Invoke();
                _state = State.Clean;
            }
        }
    }
}