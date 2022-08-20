using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class ThornyScaffoldManager : MonoBehaviour {
    public Vector2 offSize;
    public Sprite offImage;
    public float offTime = 1;
    public Vector2 onSize;
    public Sprite onImage;
    public float onTime = 1;
    public float invokeTime = 0;
    public bool isOn = false;

    //Private Value
    private Vector3 old_position, offPos, onPos;
    private RectTransform rect;
    private Image image;
    private BoxCollider2D collider;
    private float time = 0, gap = 0;
    private bool active = false;
    void Start() {
        gameObject.name = "[Obstacle] Thorny Scaffold";
        old_position = GetComponent<RectTransform>().localPosition;
        gap = onSize.y / 2 - offSize.y / 2;
        offPos = old_position;
        onPos = new Vector3(old_position.x, old_position.y + gap, old_position.z);
        rect = GetComponent<RectTransform>();
        rect.localPosition = isOn ? onPos : offPos;
        rect.sizeDelta = isOn ? onSize : offSize;
        this.gameObject.AddComponent<Image>();
        image = GetComponent<Image>();
        image.sprite = isOn ? onImage : offImage;
        this.gameObject.AddComponent<BoxCollider2D>();
        collider = GetComponent<BoxCollider2D>();
        collider.size = isOn? onSize : offSize;
        Invoke("Active", invokeTime);
    }
    private void Active() {
        active = true;
    }
    void Update() {
        time += Time.deltaTime;
        if (active) {
            if (isOn && time >= onTime) {
                time = 0;
                isOn = false;
                image.sprite = offImage;
                rect.sizeDelta = offSize;
                rect.localPosition = offPos;
            } else if (!isOn && time >= offTime) {
                time = 0;
                isOn = true;
                image.sprite = onImage;
                rect.sizeDelta = onSize;
                rect.localPosition = onPos;
            }
        }
    }
}