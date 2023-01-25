using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller2D : RaycastController2D
{
    public collisionInfo _Collisioninfo;
    public LayerMask collisionMask;
    
    private void Awake()
    {
        pa = PlayerManager.GetPlayerID(transform.GetInstanceID());
        if (pa != null)
        { 
            /*Debug.Log("got player");*/
            pa.pi.controller2D = this;
        }
    }
    
    public void Move(Vector2 steps, Vector2 number)
    {
        UpdateRaycastOrigin();
        _Collisioninfo.Reset();

        if (steps.x != 0)
        {
            _Collisioninfo.faceDir = (int)Mathf.Sign(steps.x);
        }
        HorizontalCollisions(ref steps);
        if (steps.y != 0)
        { 
            VerticalCollisions(ref steps);
        }

        transform.Translate(steps);
    }

    public struct collisionInfo
    {
        public bool above, below;
        public bool left, right;
        public int faceDir;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }

    void HorizontalCollisions(ref Vector2 steps)
    {
        float directionX = _Collisioninfo.faceDir;
        float rayLength = Mathf.Abs(steps.x) + playerSkin;
        
        //if idle
        if (Mathf.Abs(steps.x) < playerSkin)
        {
            rayLength = 2 * playerSkin;
        }

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? rayCastOrigin.bottomLeft : rayCastOrigin.bottomRight;
            rayOrigin += Vector2.up * (horizontalRayspacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
            Debug.DrawRay(rayOrigin,Vector2.right*directionX,Color.red);
            if (hit)
            {
                if (hit.distance == 0)
                {
                    continue;
                }

                steps.x = (hit.distance - playerSkin) * directionX;

                _Collisioninfo.left = directionX == -1;
                _Collisioninfo.right = directionX == 1;
            }
        }
    }

    private void VerticalCollisions(ref Vector2 steps)
    {
        float directionY = Mathf.Sign(steps.x);
        float rayLength = Mathf.Abs(steps.y) + playerSkin;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? rayCastOrigin.bottomLeft : rayCastOrigin.topLeft;
            rayOrigin += Vector2.right * (verticalRayspacing * i + steps.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            Debug.DrawRay(rayOrigin,Vector2.up*directionY,Color.red);
            if (hit)
            {
                steps.y = (hit.distance - playerSkin) * directionY;
                rayLength = hit.distance;
                _Collisioninfo.below = directionY == -1;
                _Collisioninfo.above = directionY ==  1;
                
            }
        }
    }
    
    

    
}


