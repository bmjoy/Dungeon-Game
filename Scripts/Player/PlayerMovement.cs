using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    [SerializeField] float _moveSpeed = 8f;
    [SerializeField] float _rotationSpeed = 720f;

    float _horizontal;
    float _vertical;
    bool _movementEnabled = true;

    Animator _animator;

    void Start() => _animator = GetComponent<Animator>();

    void Update()
    {
        _horizontal = _joystick.Horizontal;
        _vertical = _joystick.Vertical;
    }

    void FixedUpdate()
    {
        if (_movementEnabled)
        {
            Vector3 movementInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            float magnitude = movementInput.magnitude;
            _animator.SetFloat("Speed", magnitude);

            Vector3 inputDirection = new Vector3(_horizontal, 0, _vertical).normalized;
            transform.Translate(inputDirection * _moveSpeed * magnitude * Time.deltaTime, Space.World);

            if (inputDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(inputDirection, Vector3.up);
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
