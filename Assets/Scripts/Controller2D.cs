using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {
    
    private const float SkinWidth = 0.15f;
    public int xRayCount = 4;
    public int yRayCount = 4;

    private float _xRaySpacing;
    private float _yRaySpacing;
    
    private BoxCollider2D _collider;
    private RayCastOrigins _rayCastOrigins;
    
    // Start is called before the first frame update
    void Start() {
        _collider = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update() {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < yRayCount; i++) {
            Debug.DrawRay(_rayCastOrigins.bottomLeft + Vector2.right * (_yRaySpacing * i), Vector2.down, Color.red);
        }
    }

    void UpdateRaycastOrigins() {
        Bounds bounds = _collider.bounds;
        bounds.Expand(SkinWidth * -1);

        _rayCastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        _rayCastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        _rayCastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        _rayCastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing() {
        Bounds bounds = _collider.bounds;
        bounds.Expand(SkinWidth * -1);     
        
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