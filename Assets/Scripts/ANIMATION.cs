/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //need these for animation and physics
    private Rigidbody2D _rigbod;
    private Animator _pvtanimator;

    private bool _facingRight = true;

    //variables to play test with
    public float speed = 2.0f;
    public float walk;

    //Start is called before the first frame update
    private void Start()
    {
        //get and define game objects placed upon the player
        _rigbod = GetComponent<Rigidbody2D>();
        _pvtanimator = GetComponent<Animator>();
    }

    //used to get input from player
    private void Update()
    {
        //check direction player wants to move in
        walk = Input.GetAxisRaw("Horizontal");


    }

    //executes the above input 
    private void FixedUpdate()
    {
        //move the player in said direction
        _rigbod.velocity = new Vector2(walk * speed, _rigbod.velocity.y);
        FlipPlayer(walk);
        _pvtanimator.SetFloat("speed",walk);
    }

    private void FlipPlayer(float horizontal)
    {
       if (_facingRight == true && horizontal <0 || _facingRight == false && horizontal>0)
        {
            _facingRight = !_facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        } 
    }
}
*/
