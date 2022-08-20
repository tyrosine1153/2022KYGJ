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
    private Image image;
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

        //Child Object setting

        GameObject child = new GameObject("Child");
        child.transform.parent = this.transform;
        child.AddComponent<RectTransform>(); {
            RectTransform rect = child.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.localPosition = new Vector2(0, (onSize.y - offSize.y) / 2);
            rect.sizeDelta = onSize;
        }
        child.AddComponent<Image>(); {
            image = child.GetComponent<Image>();
            image.sprite = onImage;
        }
    }
    private void Update() {
        time += Time.deltaTime;
        if (time >= disabledTime) {
            image.enabled = false; GetComponent<Image>().enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.collider.CompareTag("Player") || collision.collider.CompareTag("Box")) && time >= disabledTime) {
            if (collision.collider.GetComponent<Rigidbody2D>() != null) {
                time = 0;
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
                image.enabled = true; GetComponent<Image>().enabled = false;
            }
        }
    }
}
