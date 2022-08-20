using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class JumpingPodManager : MonoBehaviour {
    public Sprite offImage;
    public Vector2 offSize;
    public Sprite onImage;
    public Vector2 onSize;
    public float force;
    public float disabledTime = 1;
    private float time = 0;
    void Start() {
        gameObject.name = "[Object] JumpingPod";
        //parent Object setting
        gameObject.GetComponent<RectTransform>().sizeDelta = offSize;
        gameObject.AddComponent<BoxCollider2D>(); {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = offSize;
        }
        gameObject.AddComponent<Image>();
        gameObject.GetComponent<Image>().sprite = offImage;
    }
    private void Update() {
        time += Time.deltaTime;
        if (time >= disabledTime) {
            GetComponent<Image>().sprite = offImage;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.collider.CompareTag("Player") || collision.collider.CompareTag("Box")) && time >= disabledTime) {
            if (collision.collider.GetComponent<Rigidbody2D>() != null) {
                time = 0;
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
                GetComponent<Image>().sprite = onImage;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") {
            if(collision.collider.GetComponent<Rigidbody2D>() != null) {

            }
        }
    }
}
