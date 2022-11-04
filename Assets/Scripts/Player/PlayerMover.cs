using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _reversal;
    [SerializeField] private float _acceleration;
    
    private EntranceToArchway _entranceToArchway;
    
    public bool IsExpedited { get; private set; }

    public event UnityAction<bool> Acceleration;

    private void Awake()
    {
        _entranceToArchway = GetComponent<EntranceToArchway>();
        _currentSpeed = _defaultSpeed;
    }

    private void OnEnable()
    {
        _entranceToArchway.CollisionWithCube += OnBacktrack;
        _entranceToArchway.CleanMovement += OnExpedite;
        _finishLine.LevelComplete += OnSlowDown;
    }

    private void OnDisable()
    {
        _entranceToArchway.CollisionWithCube -= OnBacktrack;
        _entranceToArchway.CleanMovement -= OnExpedite;
        _finishLine.LevelComplete -= OnSlowDown;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xPosition = 0;
        float yPosition = 0;
        
        transform.Translate(xPosition, yPosition, _currentSpeed * Time.deltaTime, Space.World);
    }

    private void OnSlowDown()
    {
        StartCoroutine(StartSlowDown());
    }

    private void OnBacktrack()
    {
        StartCoroutine(Backtrack());
    }

    private void OnExpedite()
    {
        StartCoroutine(Expedite());
    }

    private IEnumerator StartSlowDown()
    {
        float elapsed = 0f;
        float duration = 2f;
        float target = 0;

        while (elapsed < duration)
        {
            _currentSpeed = Mathf.Lerp(_defaultSpeed, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
    }

    private IEnumerator Backtrack()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        _currentSpeed = _reversal;
        yield return waitForSeconds;
        _currentSpeed = _defaultSpeed;
    }

    private IEnumerator Expedite()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3);
        
        Acceleration?.Invoke(IsExpedited = true);
        _currentSpeed = _acceleration;
        yield return waitForSeconds;
        _currentSpeed = _defaultSpeed;
        Acceleration?.Invoke(IsExpedited = false);
    }
}