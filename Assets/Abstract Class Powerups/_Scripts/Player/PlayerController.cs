using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _col;

    // Player Movement Variables
    [SerializeField] private float moveSpeed = 5;
    private Vector2 _movementDirection;
    


    // Input System Variables
    [SerializeField] private PlayerInputControls _playerControls;
    private InputAction _move;

    private void OnEnable()
    {
        _move = _playerControls.Player.Move;
        _move.Enable();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerInputControls();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _movementDirection = _move.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movementDirection.x * moveSpeed, _movementDirection.y * moveSpeed);
    }

}
