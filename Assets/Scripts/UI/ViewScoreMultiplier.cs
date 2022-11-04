using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ViewScoreMultiplier : MonoBehaviour
{
    [SerializeField] private EntranceToArchway _entranceToArchway;
    [SerializeField] private TextMeshProUGUI _multiplierText;
    [SerializeField] private ScoreMultiplier _scoreMultiplier;


    private float _startPosition;

    private void OnEnable()
    {
        _entranceToArchway.CleanMovement += OnShowTemporarily;
    }

    private void OnDisable()
    {
        _entranceToArchway.CleanMovement -= OnShowTemporarily;
    }

    private void Awake()
    {
        _startPosition = transform.localPosition.x;
    }

    private void Update()
    {
        _multiplierText.text = "x" + _scoreMultiplier.CurrentMultiplier.ToString();
    }

    private void OnShowTemporarily()
    {
        StartCoroutine(ShowTemporarily());
    }

    private IEnumerator ShowTemporarily()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3);

        float position = -590;
        float duration = 0.5f;

        transform.DOLocalMoveX(position, duration);
        yield return waitForSeconds;
        transform.DOLocalMoveX(_startPosition, duration);
    }
}