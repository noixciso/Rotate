using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] private EntranceToArchway _entranceToArchway;
    
    private int _currentMultiplier;
    private int _defaultMultiplier = 1;

    public int CurrentMultiplier
    { 
        get => _currentMultiplier;
        private set => _currentMultiplier = value;
    }

    private void OnEnable()
    {
        _entranceToArchway.CleanMovement += IncrementMultiplier;
        _entranceToArchway.CollisionWithCube += ResetMultiplier;
    }

    private void OnDisable()
    {
        _entranceToArchway.CleanMovement -= IncrementMultiplier;
        _entranceToArchway.CollisionWithCube -= ResetMultiplier;
    }

    private void Start()
    {
        _currentMultiplier = _defaultMultiplier;
    }

    private void IncrementMultiplier()
    {
        CurrentMultiplier++;
    }
    
    private void ResetMultiplier()
    {
        CurrentMultiplier = _defaultMultiplier;
    }
}
