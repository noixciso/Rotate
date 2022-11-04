using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalutVFX : MonoBehaviour
{
    [SerializeField] private FinishLine _finishLine;
    [SerializeField] private ParticleSystem[] _vfx;

    private void OnEnable()
    {
        _finishLine.LevelComplete += OnControlVFX;
    }

    private void OnDisable()
    {
        _finishLine.LevelComplete += OnControlVFX;
    }

    private void OnControlVFX()
    {
        foreach (var item in _vfx)
        {
            item.Play();
        }
    }
}