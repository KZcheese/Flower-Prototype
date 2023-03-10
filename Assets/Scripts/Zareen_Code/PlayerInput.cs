using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        PlayerManager.ExecuteDirectionalUserInput(directionalInput);

        if (Input.GetAxisRaw("Jump") != 0f)
        {
            //call jump event
            PlayerManager.ExecuteJumpInput();
        }
    }
}
