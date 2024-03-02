using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private float _volumeStepTime = 0.1f;
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 1f;

    public void TurnDown(float volumeStep) => StartCoroutine(ChangeVolume(_maxVolume, 0, volumeStep));

    public void TurnUp(float volumeStep) => StartCoroutine(ChangeVolume(0, _maxVolume, volumeStep));

    private IEnumerator ChangeVolume(float startVolume, float endVolume, float stepVolume)
    {
        float currentVolume = startVolume;
        WaitForSeconds wait = new WaitForSeconds(_volumeStepTime);

        while (currentVolume != endVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(currentVolume, endVolume, stepVolume);
            currentVolume = _audioSource.volume;

            yield return wait;
        }
    }
}
