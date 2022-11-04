using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ScoreMultiplier _scoreMultiplier;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        PlayerPrefs.GetInt(ScoreStorage.Score.ToString());
        ResetScore();
    }

    public int IncrementScore(int reward)
    {
        int rewardForOneEvent = reward * _scoreMultiplier.CurrentMultiplier;
        
        ScoreStorage.Score += rewardForOneEvent;
        ScoreChanged?.Invoke(ScoreStorage.Score);
        return rewardForOneEvent;
    }

    private void ResetScore()
    {
        ScoreStorage.Score = 0;
        ScoreChanged?.Invoke(ScoreStorage.Score);
    }
}