using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _maxMoveSpeed = 4f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _triggerDistance = 0.2f;

    private float _moveSpeed;

    public IEnumerator GoToTarget(Transform target)
    {
        while ((transform.position - target.position).magnitude > _triggerDistance)
        {
            Move(target);

            yield return null;
        }

        _animator.SetFloat(Speed, 0);
    }

    private void Move(Transform target)
    {
        _moveSpeed = (target.position - transform.position).magnitude;

        if (_moveSpeed > _maxMoveSpeed)
            _moveSpeed = _maxMoveSpeed;

        _animator.SetFloat(Speed, _moveSpeed);

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}