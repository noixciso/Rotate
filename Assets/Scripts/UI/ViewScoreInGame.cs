using DG.Tweening;
using UnityEngine;

public class ViewScoreInGame : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;

    private void OnEnable()
    {
        _finishLine.LevelComplete += OnHideScore;
    }

    private void OnDisable()
    {
        _finishLine.LevelComplete -= OnHideScore;
    }
    
    private void OnHideScore()
    {
        float scoreYPosition = 1662;
        float duration = 0.5f;
        
        transform.DOLocalMoveY(scoreYPosition, duration);
    }
}
