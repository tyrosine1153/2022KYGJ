using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpingPodCollider : MonoBehaviour {
    private void Start() {
        manager = this.transform.parent.GetComponent<JumpingPodManager>();
    }
    private JumpingPodManager manager;
    private float time = 0;
    private void Update() {
        time += Time.deltaTime;
        if (time >= manager.disabledTime) {GetComponent<Image>().enabled = false;}
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Box") || collision.collider.CompareTag("Mirror")) {
            if (collision.collider.GetComponent<Rigidbody2D>() != null && time >= manager.disabledTime) {
                GetComponent<Image>().enabled = true;
                time = 0;
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * manager.force);
            }
        }
    }
}