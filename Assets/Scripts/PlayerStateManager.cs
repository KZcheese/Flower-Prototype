using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
    public int health = 1;

    public void HurtPlayer() {
        health--;
        Debug.Log("Ouch!");
        if (health <= 0) {
            Debug.Log("Game Over");
        }
    }
}
