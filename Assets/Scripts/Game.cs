using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ViewEndScreen _viewEndScreen;

    private void Awake()
    {
        Time.timeScale = 1;
        _playerInput.enabled = true;
    }

    private void OnEnable()
    {
        _finishLine.LevelComplete += OnLevelComplete;
        _finishLine.LevelComplete += OnShowResultScreen;
    }

    private void OnDisable()
    {
        _finishLine.LevelComplete -= OnLevelComplete;
        _finishLine.LevelComplete -= OnShowResultScreen;
    }

    private void OnLevelComplete()
    {
        _playerInput.enabled = false;
    }

    private void OnShowResultScreen()
    {
        _viewEndScreen.StartCoroutine(_viewEndScreen.StartShowResultScreen());
    }
}
