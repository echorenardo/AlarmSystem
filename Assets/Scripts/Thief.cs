using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _victim;
    [SerializeField] private Transform _escapePoint;
    [SerializeField] private float _timeForRob = 5f;

    private event Action IsRobbed;

    private void Start() => StartCoroutine(_mover.GoToTarget(_victim));
    private void OnEnable() => IsRobbed += Escape;
    private void OnDisable() => IsRobbed -= Escape;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Car>(out Car car) == true)
            gameObject.SetActive(false);

        if (other.TryGetComponent<AlarmSystem>(out AlarmSystem alarmSystem) == true)
            StartCoroutine(Rob());
    }

    private IEnumerator Rob()
    {
        yield return new WaitForSeconds(_timeForRob);

        IsRobbed?.Invoke();
    }

    private void Escape() => StartCoroutine(_mover.GoToTarget(_escapePoint));
}