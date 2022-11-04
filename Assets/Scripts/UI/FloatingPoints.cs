using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloatingPoints : MonoBehaviour
{
    [SerializeField] private EntranceToArchway _entranceToArchway;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _floatingPoint;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private FinishLine _finishLine;

    private const int AccelerationReward = 1;
    private const int DefaultReward = 10;
    private const int FinishReward = 300;

    private Vector3 _actualPlayerPosition;

    private void OnEnable()
    {
        _entranceToArchway.CleanMovement += OnLaunchingDefaultPoints;
        _entranceToArchway.DirtyMovement += OnLaunchingDefaultPoints;
        _playerMover.Acceleration += OnLaunchingAccelerationPoints;
        _finishLine.LevelComplete += OnLaunchingFinishPoint;
    }

    private void OnDisable()
    {
        _entranceToArchway.CleanMovement -= OnLaunchingDefaultPoints;
        _entranceToArchway.DirtyMovement -= OnLaunchingDefaultPoints;
        _playerMover.Acceleration -= OnLaunchingAccelerationPoints;
        _finishLine.LevelComplete -= OnLaunchingFinishPoint;
    }

    private void FixedUpdate()
    {
        _actualPlayerPosition = _player.transform.localPosition;
    }

    private void OnLaunchingDefaultPoints()
    {
        StartCoroutine(StartCreateFloatPoint(DefaultReward));
    }

    private void OnLaunchingAccelerationPoints(bool IsExpedited)
    {
        float time = 0.3f;
        float repeat = 0.3f;
        
        if (IsExpedited)
        {
            InvokeRepeating("LaunchingAccelerationPoints", time, repeat);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void LaunchingAccelerationPoints()
    {
        StartCoroutine(StartCreateFloatPoint(AccelerationReward));
    }

    private void OnLaunchingFinishPoint()
    {
        StartCoroutine(StartCreateFloatPoint(FinishReward));
    }

    private IEnumerator StartCreateFloatPoint(int reward)
    {
        float duration = 1;
        float localMoveY = 1073;
        float scale = 0;
        WaitForSeconds waitForSeconds = new WaitForSeconds(2);
        TextMeshProUGUI floatPoint = Instantiate(_floatingPoint, transform);
        
        floatPoint.text = "+" + _player.IncrementScore(reward).ToString();
        floatPoint.transform.localPosition = _actualPlayerPosition;
        floatPoint.transform.DOLocalMoveY(localMoveY, duration);
        floatPoint.transform.DOScale(scale, duration);
        yield return waitForSeconds;
        Destroy(floatPoint.gameObject);
    }
}