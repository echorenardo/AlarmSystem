using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private List<Wheel> _wheels = new List<Wheel>();
    [SerializeField] private Engine _engine;
    [SerializeField] private float _maxWheelSpeed = 1000f;
    [SerializeField] private float _maxMoveSpeed = 10f;
    [SerializeField] private float _triggerDistance = 0.3f;

    private float _moveSpeed = 0;
    private float _wheelSpeed = 0;
    private float _wheelSpeedCoefficient = 200;

    public IEnumerator GoToTarget(Transform target)
    {
        _engine.Fire();

        while ((transform.position - target.position).magnitude > _triggerDistance)
        {
            RotateWheels();
            Move(target);

            yield return null;
        }

        _wheelSpeed = 0;
        _moveSpeed = 0;
    }

    private void Move(Transform target)
    {
        _moveSpeed += Time.deltaTime;

        if (_moveSpeed > _maxMoveSpeed)
            _moveSpeed = _maxMoveSpeed;

        _engine.BurnFuelUnit(_moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
    }

    private void RotateWheels()
    {
        _wheelSpeed += Time.deltaTime * _wheelSpeedCoefficient;

        if (_wheelSpeed > _maxWheelSpeed)
            _wheelSpeed = _maxWheelSpeed;

        foreach (Wheel wheel in _wheels)
            wheel.Rotate(_wheelSpeed);
    }
}
