using UnityEngine;

public class HazardManager : MonoBehaviour {
    // Start is called before the first frame update
    public PlayerStateManager playerStateManager;

    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Collision detected");
        if (!col.gameObject.CompareTag("Player")) return;
        playerStateManager.HurtPlayer();
    }
}