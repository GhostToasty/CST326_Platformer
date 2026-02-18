using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class CharacterDriver : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    // underscore shows that variable is private and local to file 
    CharacterController _controller;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0;

        if (Keyboard.current.dKey.isPressed)
            direction += 1f;

        if (Keyboard.current.aKey.isPressed)
            direction -= 1f;

        float deltaX = direction * walkSpeed * Time.deltaTime;
        Vector3 deltaPosition = new Vector3(deltaX, 0f, 0f);
        _controller.Move(deltaPosition);
    }
}
