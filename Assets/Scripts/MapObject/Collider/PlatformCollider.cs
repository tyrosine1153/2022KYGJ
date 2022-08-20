using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformCollider : MonoBehaviour {
    private void Break() {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Image>().enabled = false;
        Invoke("Recover", manager.recoverTime);
    }
    private void Recover() {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Image>().enabled = true;
    }
    private PlatformManager manager;
    private void Start() {
        manager = this.transform.parent.GetComponent<PlatformManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (manager.isbreaking) {
            Invoke("Break", manager.breakTime);
        }
        collision.transform.parent = this.transform;
    }
    private void OnCollisionExit2D(Collision2D collision) {
        collision.transform.parent = this.transform.parent.parent;
    }
}
