using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPodTrigger : MonoBehaviour {
    private void Start() {
        manager = this.transform.parent.GetComponent<JumpingPodManager>();
    }
    private JumpingPodManager manager;
    private float time = 0;
    private void Update() {
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Rigidbody2D>() != null && time >= manager.disabledTime) {
            time = 0;
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * manager.force);
        }
    }
}