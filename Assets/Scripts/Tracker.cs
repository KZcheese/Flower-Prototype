using UnityEngine;

public class Tracker : MonoBehaviour {
    public Transform trackedObject;

    public float updateSpeed = 15;

    public Vector2 trackingOffset;

    // Update is called once per frame
    void LateUpdate() {
        var cameraPosition = transform.position;
        Vector3 cameraMovement = Vector3.MoveTowards(cameraPosition, trackedObject.position + (Vector3)trackingOffset,
            updateSpeed * Time.deltaTime);
        cameraMovement.z = cameraPosition.z;
        
        transform.position = cameraMovement;
    }
}