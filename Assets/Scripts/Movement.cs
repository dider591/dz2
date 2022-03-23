using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    private const string Walk = "Walk";

    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;   

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(Walk, false);

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(Walk, true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(Walk, true);
            transform.Translate(_speed * Time.deltaTime * - 1, 0, 0);
        }
    }
}