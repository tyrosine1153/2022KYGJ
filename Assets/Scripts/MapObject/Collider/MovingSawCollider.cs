using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSawCollider : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.GetComponent<CharacterController>().GetDamage();
        }
    }
}
