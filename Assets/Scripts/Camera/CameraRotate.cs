using DG.Tweening;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private float _duration = 1;


    private void Start()
    {
        gameObject.transform.DORotate(_target.transform.rotation.eulerAngles, _duration);
        gameObject.transform.DOMoveX(_target.transform.position.x, _duration);
        gameObject.transform.DOMoveY(_target.transform.position.y, _duration);
    }
}