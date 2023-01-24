using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public PlayerInfo pi;

    public struct PlayerInfo
    {
        int instanceID;
        public PlayerMovement playerMovement;

        public PlayerInfo(int instanceID)
        {
            this.instanceID = instanceID;
            playerMovement = null;
        }
    }

    private void Awake()
    {
        PlayerManager.playerIndex.Add(transform.GetInstanceID(), this);
        pi = new PlayerInfo(transform.GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
