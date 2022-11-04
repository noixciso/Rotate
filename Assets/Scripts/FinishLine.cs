using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public event UnityAction LevelComplete;

    private void OnCollisionEnter(Collision other)
    {
        LevelComplete?.Invoke();
    }
}