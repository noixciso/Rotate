using DG.Tweening;
using UnityEngine;

public class ViewLevel : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;

    private void OnEnable()
    {
        _finishLine.LevelComplete += OnHideLevel;
    }

    private void OnDisable()
    {
        _finishLine.LevelComplete -= OnHideLevel;
    }

    private void OnHideLevel()
    {
        float levelYPosition = 1798;
        float duration = 0.5f;
        
        transform.DOLocalMoveY(levelYPosition, duration);
    }
    
    
}
