using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterManager : MonoBehaviour {
    public float speed = 0.2f;
    private Rigidbody2D rigid;
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        rigid.drag = 0;
        rigid.angularDrag = 0;
    }
    private int x = 0;
    void Update() {
        if (Input.GetKey(KeyCode.D)) { x++; }
        if (Input.GetKey(KeyCode.A)) { x--; }
    }
    void LateUpdate() {
        rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
    }
}