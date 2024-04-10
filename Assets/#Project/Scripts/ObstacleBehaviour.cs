using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerControl pc = collision.gameObject.GetComponent<PlayerControl>();
            if (pc is not null) {
                pc.Respawn();
            }
        }
    }
}
