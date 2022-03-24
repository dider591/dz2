using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _duration = 0.3f;
    private float _volumeMax = 1.0f;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        _coroutine = StartCoroutine(BalanceVolume());
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
            _audioSource.volume = Mathf.PingPong(Time.time * _duration, _volumeMax);
            yield return null;
        }        
    }
}

