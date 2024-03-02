using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private CarMover _mover;
    [SerializeField] private HeadLights _headLights;

    private void Start() => _headLights.Disable();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief) == true)
        {
            StartCoroutine(_mover.GoToTarget(_targetPoint));
            _headLights.Enable();
        }
    }
}