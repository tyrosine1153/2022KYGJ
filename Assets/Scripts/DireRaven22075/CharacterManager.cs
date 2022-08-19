using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(AudioSource))]
public class CharacterManager : MonoBehaviour {
    void Start() {
        
    }
    int x = 0, y = 0;
    void Update() {
        if (Input.GetKey(KeyCode.A)) { x--; }
        if (Input.GetKey(KeyCode.D)) { x++; }
    }
}