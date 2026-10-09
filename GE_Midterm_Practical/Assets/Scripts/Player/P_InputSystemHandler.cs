using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_InputSystemHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputSystem;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Bubble_Spawner bubbleSpawner;

    private P_Player player;
    //[SerializeField] E_Base_Enemy _enemy;

    private InputActionMap _playerActions;
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _jumpAction;
    private Vector2 _moveDir;

    [Header("Movement Variables")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpStrength;
    private bool isGrounded;

    [Header("Attack Variables")]
    [SerializeField] private float _animationDuration = 0.1f;
    [SerializeField] private float _knockbackStrength = 1.5f;
    private bool _isAttacking = false;

    private void Awake()
    {
        player = GetComponent<P_Player>();
        _rb = GetComponent<Rigidbody2D>();
        _playerActions = InputSystem.actions.FindActionMap("Player");
        _moveAction = InputSystem.actions.FindAction("Move");
        _attackAction = InputSystem.actions.FindAction("Attack");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        bubbleSpawner = FindAnyObjectByType<Bubble_Spawner>();
    }

    
    private void OnEnable()
    {
        _playerActions.Enable();
    }
    private void OnDisable()
    {
        _playerActions.Disable();
    }
    private void Update()
    {
        _moveDir = _moveAction.ReadValue<Vector2>();

        if (_moveDir.sqrMagnitude >= 0.0001)
        {
            Quaternion lookDir = Quaternion.LookRotation(Vector3.forward, _moveDir);
            transform.rotation = (lookDir);
        }


        Camera.main.transform.rotation = Quaternion.identity;
        
        if (_attackAction.WasCompletedThisFrame() && !_isAttacking)
        {
            StartCoroutine(Attack());
        }

        HandleJump();
    }
    private void FixedUpdate()
    {
        _rb.AddForce(_moveDir * _moveSpeed, ForceMode2D.Force);
    }

    private void HandleJump()
    {
        Debug.Log(isGrounded);
        if (_rb.linearVelocityY < 0.02f)
        {
            isGrounded = true;
        }

        if (_jumpAction.WasCompletedThisFrame() && isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private IEnumerator Attack()
    {
        
        _isAttacking = true;
        bubbleSpawner.SpawnBubble();
        yield return new WaitForSeconds(_animationDuration);
        _isAttacking = false;

    }
}
