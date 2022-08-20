using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornyScaffoldTrigger : MonoBehaviour {
    private ThornyScaffoldManager manager;
    void Start() {
        manager = transform.parent.GetComponent<ThornyScaffoldManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (manager.isOn && collision.CompareTag("Player")) {
            collision.GetComponent<CharacterController>().GetDamage();
        }
    }
}
