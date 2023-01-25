using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] public float maxjumpHeight = 4;
    [SerializeField] public float minjumpHeight = 1;
    [SerializeField] public float timetoApex = 0.4f;
    [SerializeField] public float speed = 6f;
    public PlayerInfo pi;
    [SerializeField] public float accelerationtimeGrounded=0.1f;
    [SerializeField] public float accelerationtimeAirborne=0.2f;

    public struct PlayerInfo
    {
        int instanceID;
        public PlayerMovement playerMovement;
        public Controller2D controller2D;
        public Vector3 velocity;
        public Vector2 directionalInput;
        public float gravity;
        public float maxjumpVelocity;
        public float minjumpVelocity;
        public float velocitySmoothing;
        
        

        public PlayerInfo(int instanceID)
        {
            this.instanceID = instanceID;
            playerMovement = null;
            controller2D = null;
            velocity = Vector3.zero;
            directionalInput = Vector2.zero;
            gravity = 0;
            maxjumpVelocity = 0;
            minjumpVelocity = 0;
            velocitySmoothing = 0;
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
