using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterManager : MonoBehaviour {
    void Start() {
        
    }
    int x = 0, y = 0;
    void Update() {
        if (Input.GetKey(KeyCode.A)) { x--; }
        if (Input.GetKey(KeyCode.D)) { x++; }
    }
}