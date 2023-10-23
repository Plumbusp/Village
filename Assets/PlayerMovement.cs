using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    ActionMap _actionMap;
    InputAction _moveInputAction;
    InputAction _fireInputAction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _actionMap = new ActionMap();

        _moveInputAction = _actionMap.Player.Move;
        _moveInputAction.Enable();
        _moveInputAction.performed += Jump;
        _fireInputAction = _actionMap.Player.Fire;
        _fireInputAction.Enable();
    }
    private void OnDisable()
    {
        _moveInputAction.Disable();
        _fireInputAction.Disable();
    }
    private void Jump(InputAction.CallbackContext callback)
    {
        rb.AddForce(Vector2.up * 60f);
    }
}
