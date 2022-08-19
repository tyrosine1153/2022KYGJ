using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTest : MonoBehaviour {
    Vector3 pos;
    void Start() {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.position = pos;
        }
        
    }
}
