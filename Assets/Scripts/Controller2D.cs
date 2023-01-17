using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {
    public LayerMask collisionMask;

    private const float SkinWidth = 0.15f;
    public int xRayCount = 4;
    public int yRayCount = 4;

    private float _xRaySpacing;
    private float _yRaySpacing;

    private BoxCollider2D _collider;
    private RayCastOrigins _rayCastOrigins;

    // Start is called before the first frame update
    void Awake() {
        _collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    public void Move(Vector2 velocity) {
        UpdateRaycastOrigins();

        if (velocity.x != 0)
            HorizontalCollisions(ref velocity);
        if (velocity.y != 0)
            VerticalCollisions(ref velocity);

        transform.Translate(velocity);
        Physics2D.SyncTransforms();
    }

    void HorizontalCollisions(ref Vector2 velocity) {
        int xDirection = Math.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + SkinWidth;
        for (int i = 0; i < yRayCount; i++) {
            Vector2 rayOrigin = xDirection == -1 ? _rayCastOrigins.bottomLeft : _rayCastOrigins.bottomRight;
            rayOrigin += Vector2.up * (_xRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * xDirection, rayLength, collisionMask);

            // Show Rays
            Debug.DrawRay(rayOrigin, Vector2.right * (xDirection * rayLength), Color.red);

            if (hit) {
                velocity.x = (hit.distance - SkinWidth) * xDirection;
                rayLength = hit.distance;
            }
        }
    }

    void VerticalCollisions(ref Vector2 velocity) {
        int yDirection = Math.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + SkinWidth;
        for (int i = 0; i < yRayCount; i++) {
            Vector2 rayOrigin = yDirection == -1 ? _rayCastOrigins.bottomLeft : _rayCastOrigins.topLeft;
            rayOrigin += Vector2.right * (_yRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * yDirection, rayLength, collisionMask);

            // Show Rays
            Debug.DrawRay(rayOrigin, Vector2.up * (yDirection * rayLength), Color.red);

            if (hit) {
                velocity.y = (hit.distance - SkinWidth) * yDirection;
                rayLength = hit.distance;
            }
        }
    }


    void UpdateRaycastOrigins() {
        Bounds bounds = _collider.bounds;
        bounds.Expand(SkinWidth * -2);

        _rayCastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        _rayCastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        _rayCastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        _rayCastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing() {
        Bounds bounds = _collider.bounds;
        bounds.Expand(SkinWidth * -2);

        xRayCount = Mathf.Clamp(xRayCount, 2, int.MaxValue);
        yRayCount = Mathf.Clamp(yRayCount, 2, int.MaxValue);

        _xRaySpacing = bounds.size.y / (xRayCount - 1);
        _yRaySpacing = bounds.size.x / (yRayCount - 1);
    }

    struct RayCastOrigins {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}