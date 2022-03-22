using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntersHouse : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _duration = 0.3f;
    private float _volumeMax = 1.0f;
    private float _volumeMin = 0.2f;
    private float _current;
    private Coroutine coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _current = _audioSource.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        coroutine = StartCoroutine(BalanceAlarmVolume());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.Stop();
        StopCoroutine(coroutine);
    }

    private IEnumerator BalanceAlarmVolume()
    {
        while (true)
        {
            while(_current != _volumeMin)
            {               
                _current = Mathf.MoveTowards(_current, _volumeMin, Time.deltaTime * _duration);
                _audioSource.volume = _current;
                yield return null;
            }

            while (_current != _volumeMax)
            {               
                _current = Mathf.MoveTowards(_current, _volumeMax, Time.deltaTime * _duration);
                _audioSource.volume = _current;
                yield return null;
            }           
        }
    }
}

