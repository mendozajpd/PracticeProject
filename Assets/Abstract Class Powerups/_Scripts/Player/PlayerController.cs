using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour
{

    // Player Variables
    private Rigidbody2D _rb;
    private CircleCollider2D _col;
    private Health _health;

    // Player Movement Variables
    [SerializeField] private float moveSpeed = 5;
    private Vector2 _movementDirection;


    // Appearance Variables
    [SerializeField] private GameObject _spriteGameObject;

    // Input System Variables
    [SerializeField] private PlayerInputControls _playerControls;
    private InputAction _move;
    private InputAction _fire;
    private InputAction _heal;

    private void OnEnable()
    {
        // Add the value of the variable
        _move = _playerControls.Player.Move;
        _fire = _playerControls.Player.Fire;
        _heal = _playerControls.Player.Heal;

        // Subscribe the function to the event
        _fire.performed += _hurtSelf;
        _heal.performed += _healSelf;

        // Enable the input
        _fire.Enable();
        _heal.Enable();
        _move.Enable();
    }

    private void OnDisable()
    {
        _fire.performed -= _hurtSelf;
        _heal.performed -= _healSelf;

        _fire.Disable();
        _heal.Disable();
        _move.Disable();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerInputControls();
        _health = GetComponent<Health>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _movementDirection = _move.ReadValue<Vector2>().normalized;
        _spriteFlipper();
    }

    private void _spriteFlipper()
    {
        if (_movementDirection.x < 0 && _spriteGameObject.transform.localScale.x > 0)
        {
            _spriteGameObject.transform.localScale = new Vector2(_spriteGameObject.transform.localScale.x * -1, _spriteGameObject.transform.localScale.y);
        }

        if (_movementDirection.x > 0 && _spriteGameObject.transform.localScale.x < 0)
        {
            _spriteGameObject.transform.localScale = new Vector2(_spriteGameObject.transform.localScale.x * -1, _spriteGameObject.transform.localScale.y);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movementDirection.x * moveSpeed, _movementDirection.y * moveSpeed);
    }

    private void _hurtSelf(InputAction.CallbackContext context)
    {
        _health.Damage(_health.Initial * 0.1f);
    }
    
    private void _healSelf(InputAction.CallbackContext context)
    {
        _health.Heal(_health.Initial * 0.2f);
    }
}
