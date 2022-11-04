using System.Collections;
using DG.Tweening;
using UnityEngine;

public enum TurnSide
{
    Left,
    Right
}

[RequireComponent(typeof(PlayerInput))]
public class PlayerRotation : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _degree = 90;
    private bool _isTurnAvailable = true;

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

    private void OnRotate(TurnSide turnSide)
    {
        if (_isTurnAvailable)
        {
            if (turnSide == TurnSide.Left)
            {
                StartCoroutine(Rotate(_degree));
            }
            else if (turnSide == TurnSide.Right)
            {
                StartCoroutine(Rotate(-_degree));
            }
        }
    }

    private IEnumerator Rotate(float degree)
    {
        float xRotate = 0;
        float zRotate = 0;
        float turnSpeed = 0.5f;

        _isTurnAvailable = false;
        transform.DORotate(new Vector3(xRotate, degree, zRotate), turnSpeed).SetRelative(true);
        yield return new WaitForSeconds(turnSpeed);
        _isTurnAvailable = true;
    }
}