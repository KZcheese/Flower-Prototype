using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController2D : MonoBehaviour
{
    [SerializeField]
    public Collider2D boxCollider;
    
    public const float playerSkin = 0.012f;
    public RayCastOrigin rayCastOrigin;
    const float distbwRays = 0.20f;
    [HideInInspector]
    public int horizontalRayCount;
    [HideInInspector]
    public int verticalRayCount;
    [HideInInspector]
    public float horizontalRayspacing;
    [HideInInspector]
    public float verticalRayspacing;
    protected PlayerAttributes pa;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        CalculateRayOffset();
    }

    public void UpdateRaycastOrigin()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(playerSkin*-1);

        rayCastOrigin.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        rayCastOrigin.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        rayCastOrigin.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        rayCastOrigin.topRight = new Vector2(bounds.max.x, bounds.max.y);
        rayCastOrigin.leftEdge = new Vector2(bounds.min.x, bounds.center.y);
        rayCastOrigin.rightEdge = new Vector2(bounds.max.x, bounds.center.y);
        rayCastOrigin.topEdge = new Vector2(bounds.center.x, bounds.max.y);
        rayCastOrigin.bottomEdge= new Vector2(bounds.center.x, bounds.min.y); 
        rayCastOrigin.centre = new Vector2(bounds.center.x, bounds.min.y);

    }
    public struct RayCastOrigin
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
        public Vector2 topEdge, bottomEdge,leftEdge,rightEdge,centre;
    }

    public void CalculateRayOffset()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(playerSkin*-1);

        float boundsHeight = bounds.size.y;
        float boundsWidth = bounds.size.x;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight / distbwRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / distbwRays);
        horizontalRayspacing = boundsHeight / (horizontalRayCount - 1);
        verticalRayspacing = boundsWidth / (verticalRayCount - 1);
    }
}
