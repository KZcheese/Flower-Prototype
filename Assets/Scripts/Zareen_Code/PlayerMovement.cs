using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected PlayerAttributes pa;

    public void Awake()
    {
        pa = PlayerManager.GetPlayerID(transform.GetInstanceID());
        if (pa != null)
        { 
            Debug.Log("got player");
            pa.pi.playerMovement = this;
        }
        Debug.Log("Player movement instance"+pa.pi.playerMovement+" is stored in playerInfo");

    }

    private void OnEnable()
    {
        PlayerManager.OnDirectionalInput += SetDirectionalInput;
        PlayerManager.OnJumpInput += OnJumpInputDown;
    }

    private void SetDirectionalInput(Vector2 input)
    {
        Debug.Log("walk engaged");
    }

    private void OnJumpInputDown()
    {
        Debug.Log("jump triggered");
    }

    private void OnDisable()
    {
        PlayerManager.OnDirectionalInput -= SetDirectionalInput;
        PlayerManager.OnJumpInput -= OnJumpInputDown;
    }
}
