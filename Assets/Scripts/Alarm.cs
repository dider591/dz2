using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _duration = 0.3f;
    private float _volumeMax = 1.0f;
    private float _current;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _current = _audioSource.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();

        _coroutine = StartCoroutine(BalanceAlarmVolume());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.Stop();
        StopCoroutine(_coroutine);
    }

    private IEnumerator BalanceVolume()
    {
        while (true)
        {
            _current = Mathf.PingPong(Time.time * _duration, _volumeMax);
            _audioSource.volume = _current;
            yield return null;
        }        
    }
}

