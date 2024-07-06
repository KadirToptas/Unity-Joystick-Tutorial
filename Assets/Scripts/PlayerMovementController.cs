using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private AnimationController animationController;
    
    [SerializeField] private Rigidbody rb;

    [SerializeField] private FixedJoystick fixedJoystick;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform playerTransform;
    
    private float _horizontal;
    private float _vertical;


    private void Update()
    {
        GetMovementInputs();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }


    private void SetMovement()
    {
        rb.velocity = GetNewVelocity();
        animationController.SetBoolean("Run", _horizontal != 0 || _vertical != 0);
    }


    private void SetRotation()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            playerTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
            
        }
      
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal, rb.velocity.y, _vertical) * moveSpeed * Time.fixedDeltaTime;
    }


    private void GetMovementInputs()
    {
        _horizontal = fixedJoystick.Horizontal;
        _vertical = fixedJoystick.Vertical;
    }
}
