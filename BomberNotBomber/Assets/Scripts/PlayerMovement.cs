using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 250.0f;
    public float JumpForce = 1;

   // public Joystick Joystick;

    private Rigidbody2D _body;
    private PlayerInput _playerInput;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
         
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        var joystickMove = _playerInput.actions["Move"].ReadValue<Vector2>();
        var movement = new Vector2(joystickMove.x * Speed * Time.deltaTime, _body.velocity.y);

        //float deltaX = Joystick.Horizontal * Speed * Time.deltaTime;
        //Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        //if (Input.GetButtonDown("Jump") && Mathf.Abs(_body.velocity.y) < 0.001f)
        //{
        //    _body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        //}
    }
}
