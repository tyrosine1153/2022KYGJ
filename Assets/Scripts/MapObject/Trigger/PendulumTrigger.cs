using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Enter The PendulumTrigger");
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Rigidbody2D>().AddForce(
                Vector2.ClampMagnitude(-collision.GetComponent<Rigidbody2D>().velocity, 1.5f)
            );
        }
    }
}
