using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxManager : MonoBehaviour {
    public Vector2 boxSize;
    public Sprite boxImage;
    void Start() {
        this.gameObject.tag = "Box";
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<RectTransform>().sizeDelta = boxSize;
        gameObject.AddComponent<Image>();
        GetComponent<Image>().sprite = boxImage;
    }
}
