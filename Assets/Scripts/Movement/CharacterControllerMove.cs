using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMove : MonoBehaviour, IMovement
{
    [SerializeField] private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    public void Move(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime);
    }

    private void Update()
    {
        if (characterController.isGrounded) return;
        Move(transform.GetChild(0).up * -1);
    }
}
