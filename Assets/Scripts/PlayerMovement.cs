using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private PlayerInput _input;
    private Vector2 _inputDirection;
    private Vector3 _moveDirection;
    private Rigidbody2D _rigidBody;

    private bool _isGrounded;
    

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Jump.performed += ctx => Jump();

        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _inputDirection = _input.Player.Move.ReadValue<Vector2>();
        Move(_inputDirection);
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
    }

    private void Move(Vector2 inputDirection)
    {
        _moveDirection = new Vector3(inputDirection.x, inputDirection.y, transform.position.z);
        _rigidBody.transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
