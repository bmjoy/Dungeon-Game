using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    [SerializeField] float _moveSpeed = 8f;
    [SerializeField] float _rotationSpeed = 720f;

    Animator _animator;
    Rigidbody _rigidbody;
    bool _movementEnabled = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_movementEnabled)
        {
            Vector3 movementInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

            float magnitude = movementInput.magnitude;
            _animator.SetFloat("Speed", magnitude);

            _rigidbody.MovePosition(transform.position + movementInput * Time.deltaTime * _moveSpeed);

            if (movementInput != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementInput.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
        }      
    }

    public void DisableMovement()
    {
        _movementEnabled = false;
        _animator.SetFloat("Speed", 0);
    }
}
