using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlarmSystem : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.02f;
    [SerializeField] private VolumeController _volumeController;

    private Thief _thief;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _thief))
        {
            _volumeController.TurnUp(_volumeStep);
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other) => _volumeController.TurnDown(_volumeStep);
}