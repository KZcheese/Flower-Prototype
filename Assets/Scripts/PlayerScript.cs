using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;

[RequireComponent(typeof(Controller2D))]
public class PlayerScript : MonoBehaviour {
    // private Rigidbody2D _rb;
    private float _vX;
    public float runSpeed = 1;

    private Controller2D _controller;
    
    // Start is called before the first frame update
    void Start() {
        // _rb = GetComponent<Rigidbody2D>();
        _controller = GetComponent<Controller2D>();
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
