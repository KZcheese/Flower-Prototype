using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected PlayerAttributes pa;

    public void Awake()
    {
        pa = new PlayerAttributes();

        /*Debug.Log("Player movement instance"+pa.pi.playerMovement+" is stored in playerInfo");*/

    }

    private void Start()
    {
        pa.pi.gravity = -(2 * pa.maxjumpHeight) / Mathf.Pow(pa.timetoApex, 2);
        pa.pi.maxjumpVelocity = Mathf.Abs(pa.pi.gravity) * pa.timetoApex;
        pa.pi.minjumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(pa.pi.gravity) * pa.minjumpHeight);
        
    }

    private void Update()
    {
        CalculateVelocity();
        pa.pi.controller2D.Move(pa.pi.velocity * Time.deltaTime,pa.pi.directionalInput);

        if (pa.pi.controller2D._Collisioninfo.above || pa.pi.controller2D._Collisioninfo.below)
        {
            pa.pi.velocity.y = 0;
        }
    }

    private void OnEnable()
    {
        PlayerManager.OnDirectionalInput += SetDirectionalInput;
        PlayerManager.OnJumpInput += OnJumpInputDown;
    }

    private void SetDirectionalInput(Vector2 input)
    {
        pa.pi.directionalInput = input;
    }

    private void OnJumpInputDown()
    {
        if (pa.pi.controller2D._Collisioninfo.below)
        {
            pa.pi.velocity.y = pa.pi.maxjumpVelocity;
        }
    }

    private void OnDisable()
    {
        PlayerManager.OnDirectionalInput -= SetDirectionalInput;
        PlayerManager.OnJumpInput -= OnJumpInputDown;
    }

    private void CalculateVelocity()
    {
        float targetvelocityX= pa.pi.directionalInput.x * pa.speed;
        pa.pi.velocity.x = Mathf.SmoothDamp(pa.pi.velocity.x, targetvelocityX, ref pa.pi.velocitySmoothing, (pa.pi.controller2D._Collisioninfo.below)? pa.accelerationtimeGrounded: pa.accelerationtimeAirborne);
        pa.pi.velocity.y += pa.pi.gravity * Time.deltaTime ;
    }
}
