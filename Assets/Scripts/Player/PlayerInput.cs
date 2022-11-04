using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _startTouchPosition;
    private Vector3 _endTouchPosition;

    public event UnityAction<Side> Rotate;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            if (_endTouchPosition.x < _startTouchPosition.x)
            {
                Rotate?.Invoke(Side.Left);
            }
            else if (_endTouchPosition.x > _startTouchPosition.x)
            {
                Rotate?.Invoke(Side.Right);
            }
        }
    }
}