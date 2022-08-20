using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class BarbedObjectManager : MonoBehaviour {
    public Vector2 size;
    public Sprite image;
    void Start() {
        gameObject.name = "[Obstacle] Barbed Fence";
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = size;
        gameObject.AddComponent<Image>(); {
            Image img = GetComponent<Image>();
            img.sprite = image;
        }
        gameObject.AddComponent<BoxCollider2D>(); {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = size;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.GetComponent<CharacterController>().GetDamage();
        }
    }
}
