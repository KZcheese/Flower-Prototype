using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DirectionalInput(Vector2 input);

public delegate void JumpInput();
public class PlayerManager : MonoBehaviour
{
    //player instance dictionary 
    public static Dictionary<int, PlayerAttributes> playerIndex { get; set; }= new Dictionary<int, PlayerAttributes>();
    //Events
    public static event DirectionalInput OnDirectionalInput;
    public static event JumpInput OnJumpInput;
    
    //Input methods
    public static void ExecuteDirectionalUserInput(Vector2 input){OnDirectionalInput(input);}

    public static void ExecuteJumpInput() { OnJumpInput();}
    
    //Interaction methods 
    public static PlayerAttributes GetPlayerID(int instanceId)
    {
        if (playerIndex.ContainsKey(instanceId))
        {
            return playerIndex[instanceId];
        }

        return null;
    }
}
        
    

