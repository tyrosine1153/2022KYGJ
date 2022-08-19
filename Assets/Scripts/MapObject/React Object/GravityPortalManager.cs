using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class GravityPortalManager : MonoBehaviour {
    public Vector2 portalSize;
    public Sprite portalImage;
    void Start() {
        GetComponent<RectTransform>().sizeDelta = portalSize;
        GetComponent<Image>().sprite = portalImage;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Rigidbody2D>().gravityScale = -collision.GetComponent<Rigidbody2D>().gravityScale;
        }
    }
}
