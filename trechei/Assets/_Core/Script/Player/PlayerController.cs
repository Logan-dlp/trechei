using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(JumpModule))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode keyStart = KeyCode.Return;
    [SerializeField] float speed = 5;

    private PlayerInput input;
    private Vector2 moveDirection;

    private JumpModule jumpModule;

    [SerializeField] private SceneLoader loader;
    [SerializeField] private GameManager manager;
    [SerializeField] private Timer timer;

    private void Start()
    {
        jumpModule = GetComponent<JumpModule>();
        input = GetComponent<PlayerInput>();

        InputAction _mouvement = input.actions["Mouvement"];

        _mouvement.started += OnMoveStarted;
        _mouvement.performed += OnMovePerformed;
        _mouvement.canceled += OnMoveCanceled;
    }

    private void Update()
    {
        float _moveX = moveDirection.x;
        float _moveY = moveDirection.y;

        if (Input.GetKeyDown(keyStart))
        {
            manager.InGame = true;
        }

        if (manager.InGame == true)
        {
            transform.position = transform.position + transform.forward * _moveY * speed * Time.deltaTime;
            transform.position = transform.position + transform.right * _moveX * speed * Time.deltaTime;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            manager.CursorOutGame();
            loader.LoadScene("GameOver");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Fin"))
        {
            manager.InGame = false;
            manager.CursorOutGame();
            timer.Save();
            loader.LoadScene("Win");
        }
    }
}
