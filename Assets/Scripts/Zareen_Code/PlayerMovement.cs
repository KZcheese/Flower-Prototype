using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private PlayerAttributes _pa;

    public void Awake() {
        _pa = GetComponent<PlayerAttributes>();
        /*Debug.Log("Player movement instance"+pa.pi.playerMovement+" is stored in playerInfo");*/
    }

    private void Start() {
        _pa.pi.gravity = -(2 * _pa.maxjumpHeight) / Mathf.Pow(_pa.timetoApex, 2);
        _pa.pi.maxjumpVelocity = Mathf.Abs(_pa.pi.gravity) * _pa.timetoApex;
        _pa.pi.minjumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_pa.pi.gravity) * _pa.minjumpHeight);
    }

    private void Update() {
        CalculateVelocity();
        _pa.pi.controller2D.Move(_pa.pi.velocity * Time.deltaTime, _pa.pi.directionalInput);

        if (_pa.pi.controller2D._Collisioninfo.above || _pa.pi.controller2D._Collisioninfo.below) {
            _pa.pi.velocity.y = 0;
        }
    }

    private void OnEnable() {
        PlayerManager.OnDirectionalInput += SetDirectionalInput;
        PlayerManager.OnJumpInput += OnJumpInputDown;
    }

    private void SetDirectionalInput(Vector2 input) {
        _pa.pi.directionalInput = input;
    }

    private void OnJumpInputDown() {
        if (_pa.pi.controller2D._Collisioninfo.below) {
            _pa.pi.velocity.y = _pa.pi.maxjumpVelocity;
        }
    }

    private void OnDisable() {
        PlayerManager.OnDirectionalInput -= SetDirectionalInput;
        PlayerManager.OnJumpInput -= OnJumpInputDown;
    }

    private void CalculateVelocity() {
        float targetVelocityX = _pa.pi.directionalInput.x * _pa.speed;
        float smoothTime = _pa.pi.controller2D._Collisioninfo.below
            ? _pa.accelerationtimeGrounded
            : _pa.accelerationtimeAirborne;
        _pa.pi.velocity.x =
            Mathf.SmoothDamp(_pa.pi.velocity.x, targetVelocityX, ref _pa.pi.velocitySmoothing, smoothTime);
        _pa.pi.velocity.y += _pa.pi.gravity * Time.deltaTime;
    }
}