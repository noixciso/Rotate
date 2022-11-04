using DG.Tweening;
using UnityEngine;

public enum Side
{
    Left,
    Right
}

[RequireComponent(typeof(PlayerInput))]
public class PlayerRotation : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _degree = 90;
    private float _turnSpeed = 1;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.Rotate += OnRotate;
    }

    private void OnDisable()
    {
        _playerInput.Rotate -= OnRotate;
    }

    private void OnRotate(Side side)
    {
        if (side == Side.Left)
        {
            Rotate(_degree);
        }
        else if (side == Side.Right)
        {
            Rotate(-_degree);
        }
    }

    private void Rotate(float degree)
    {
        float xRotate = 0;
        float zRotate = 0;
        
        transform.DORotate(new Vector3(xRotate, degree, zRotate), _turnSpeed).SetRelative(true);
    }
}