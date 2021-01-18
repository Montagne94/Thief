using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * _speed * Time.deltaTime);
            _spriteRenderer.flipX = false;
            _animator.Play("run");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate((transform.right * _speed) * -1 * Time.deltaTime);
            _spriteRenderer.flipX = true;
            _animator.Play("run");
        }
        else
        {
            _animator.Play("idle");
        }
    }
}
