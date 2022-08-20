using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public GameObject target;
    private Transform child;

    [SerializeField] private AnimationClip press;
    [SerializeField] private AnimationClip unpress;
    void Start() {
        animation = GetComponent<Animation>();
    }
    private Animation animation;
    private bool isPressed = false;
    private float time = 0;
    void Update() {
        time += Time.deltaTime;
        if (count > 0) {
            if (target.CompareTag("Door")) {
                if (!target.GetComponent<DoorManager>().isOpen) {
                    target.GetComponent<DoorManager>().Open();
                }
            }
        } else {
            transform.GetChild(0).transform.localPosition = new Vector2(0.5f, -0.2f);
            if (target.CompareTag("Door")) {
                if (target.GetComponent<DoorManager>().isOpen) {
                    target.GetComponent<DoorManager>().Close();
                }
            }
        }
    }
    public static float remap(float val, float in1, float in2, float out1, float out2) {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
    private int count = 0;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (count == 0) {
            animation.clip = press;
            animation.Play();
        }
        count++;
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (count - 1 == 0) {
            animation.clip = unpress;
            animation.Play();
        }
        count--;
    }
}
