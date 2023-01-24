using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode keyStart = KeyCode.Space;
    [SerializeField] private float autoSpeed = 6;
    [SerializeField] private float speed = 5f;

    [SerializeField] private int layer = 3;
    
    private PlayerInput input;
    private Vector2 moveDirection;

    public bool gameStart = false;
    private bool grounded = false;

    private void Start()
    {
        input = GetComponent<PlayerInput>();

        InputAction _mouvement = input.actions["Mouvement"];

        _mouvement.started += OnMoveStarted;
        _mouvement.performed += OnMovePerformed;
        _mouvement.canceled += OnMoveCanceled;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameStart = true;
        }
        if (gameStart == true)
        {
            transform.position += new Vector3(moveDirection.x * speed, 0, autoSpeed) * Time.deltaTime;
        }
    }

    #region Mouvement Implantation
    void OnMoveStarted(InputAction.CallbackContext _obj)
    {
        moveDirection = _obj.ReadValue<Vector2>();
    }

    void OnMovePerformed(InputAction.CallbackContext _obj)
    {
        moveDirection = _obj.ReadValue<Vector2>();
    }

    void OnMoveCanceled(InputAction.CallbackContext _obj)
    {
        moveDirection = Vector2.zero;
    }
    #endregion
}
