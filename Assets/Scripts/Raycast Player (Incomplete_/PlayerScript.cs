using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Controller2D))]
public class PlayerScript : MonoBehaviour {
    // private Rigidbody2D _rb;
    public float gravity = 10;
    public float moveSpeed = 1;
    private PlayerControls _playerControls;
    private Vector2 _velocity;

    private Controller2D _controller;

    // Start is called before the first frame update
    void Awake() {
        _controller = GetComponent<Controller2D>();
        _playerControls = new PlayerControls();
    }

    private void OnEnable() {
        _playerControls.Player.Enable();
    }

    private void OnDisable() {
        _playerControls.Player.Disable();
    }

    public void OnMove() {
        
    }

    private void Update() {

        Vector2 moveInput = _playerControls.Player.Move.ReadValue<Vector2>();

        _velocity.x = moveInput.x * moveSpeed;
        _velocity.y -= gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    // // Update is called once per frame
    // void FixedUpdate() {
    //     _rb.position += new UnityEngine.Vector2(_vX, 0) * runSpeed;
    // }
    //
    // private void OnMove(InputValue movementValue) {
    //     _vX = movementValue.Get<Vector2>().X;
    // }
}