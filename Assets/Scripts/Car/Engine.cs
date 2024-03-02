using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _minEngineFrequency;
    [SerializeField] private float _maxEngineFrequency;

    private float _engineFrequency;

    public void BurnFuelUnit(float speed)
    {
        _engineFrequency = speed;

        if (_engineFrequency < _minEngineFrequency)
            _engineFrequency = _minEngineFrequency;
        else if (_engineFrequency > _maxEngineFrequency)
            _engineFrequency = _maxEngineFrequency;

        _source.pitch = _engineFrequency;
    }

    public void Fire() => _source.Play();
}
