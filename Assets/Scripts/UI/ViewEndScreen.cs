using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ViewEndScreen : MonoBehaviour
{
    [SerializeField] private GameObject _victoryImage;
    [SerializeField] private GameObject _scoreInResultScreen;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _levelStartPosition;

    private void Start()
    {
        _levelStartPosition = _level.transform.localPosition.y;
        _victoryImage.transform.localScale = Vector3.zero;
        _nextButton.transform.localScale = Vector3.zero;
        _scoreInResultScreen.transform.localScale = Vector3.zero;
    }

    public IEnumerator StartShowResultScreen()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
        
        float alphaValue = 1;
        float victoryImageScale = 10;
        float scoreScale = 1;
        float nextButtonScale = 1;
        float duration = 1;
        
        yield return waitForSeconds;
        _canvasGroup.alpha = alphaValue;
        _victoryImage.transform.DOScale(victoryImageScale, duration);
        yield return waitForSeconds;
        _level.transform.DOLocalMoveY(_levelStartPosition, duration);
        _scoreInResultScreen.transform.DOScale(scoreScale, duration);
        yield return waitForSeconds;
        _nextButton.transform.DOScale(nextButtonScale, duration);
    }
}
