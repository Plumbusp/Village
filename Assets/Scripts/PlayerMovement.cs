using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;

    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedValueSupport;
    private Rigidbody2D rb;
    private InputActions _playerInputActions;

    private Vector3 _facingRight = new Vector3(0,0,0);
    private Vector3 _facingLeft = new Vector3(0,180,0);
    private bool _isFacingRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerInputActions = new InputActions();
        if (!_playerInputActions.Player.enabled)
            _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.performed += Jump;

        transform.rotation = Quaternion.Euler(_facingRight);
        _isFacingRight = true;
    }
    private void OnDisable()
    {
        _playerInputActions.Player.Disable();
    }
    private void Jump(InputAction.CallbackContext callback)
    {
        if (!(GameManager.Instance.gameState == GameState.paused))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void Update()
    {
        if (!(GameManager.Instance.gameState == GameState.paused))
        {
            // About move
            float currentSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            if (maxSpeed < Mathf.Abs(rb.velocity.x))
            {
                rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            }
            else
            {
                Vector2 moveVectorNormalized = _playerInputActions.Player.Move.ReadValue<Vector2>();
                rb.AddForce((new Vector2(moveVectorNormalized.x, 0) * speedValueSupport));
                if (rb.velocity.x <- 1 && !_isFacingRight)
                {
                    _playerBody.rotation = Quaternion.Euler(_facingRight);
                    _isFacingRight = true;
                }
                else if (rb.velocity.x > 1 && _isFacingRight)
                {
                    _playerBody.rotation = Quaternion.Euler(_facingLeft);
                    _isFacingRight = false;
                }
            }
        }
    }
}
