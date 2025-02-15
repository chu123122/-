using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidBody2D;
    private IsGroundTrigger _isGroundTrigger;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
        _isGroundTrigger = this.GetComponent<IsGroundTrigger>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveDirection = _playerInput.GamePlay.Move.ReadValue<Vector2>();
        if (moveDirection.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1,1,1);
        
        _rigidBody2D.velocity = new Vector2(moveDirection.x * moveSpeed, _rigidBody2D.velocity.y);
    }

    private void OnEnable()
    {
        _playerInput.GamePlay.Enable();
        _playerInput.GamePlay.Jump.started += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(_isGroundTrigger.isGround)
            _rigidBody2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        _playerInput.GamePlay.Jump.started -= Jump;
        _playerInput.GamePlay.Disable();
    }
}