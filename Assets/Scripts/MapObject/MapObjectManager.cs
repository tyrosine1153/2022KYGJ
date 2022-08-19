using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapObjectManager : MonoBehaviour {
    public float damage = 0;
    public float speed = 0;
    protected virtual void OnEnter() {}
    protected virtual void OnLeave() {}
    protected virtual void OnStay() {}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            OnEnter();
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            OnStay();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            OnLeave();
        }
    }
}
