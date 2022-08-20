using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {
    public Direction direction;
    public enum Direction {
        Up, Down
    }
    public float actTime;
    [NonSerialized] public bool isActing = false;
    Vector3 old_pos;
    void Start() {
        old_pos = this.transform.position;
        this.gameObject.name = "[Object] Door";
        collider = GetComponent<BoxCollider2D>();
    }
    BoxCollider2D collider;
    [NonSerialized] public bool isOpen = false; private float time = 0;
    public static float remap(float val, float in1, float in2, float out1, float out2) {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
    public void Open() { isOpen = true; time = time >= 3 ? 0 : time; isActing = true; }
    public void Close() { isOpen = false; time = time >= 3 ? 0 : time; isActing = true; }
    void Update() {
        time = Mathf.Clamp(time + Time.deltaTime, 0, 3);
        isActing = time < 3;
        if (direction == Direction.Up) {
            if (isOpen && time < 3) {
                //닫는 연출
                Debug.Log("닫는 연출");
                transform.position = new Vector2(old_pos.x, old_pos.y + remap(time, 0, 3f, 0, 4f));
                collider.offset = new Vector2(0, remap(time, 0, actTime, 0, -0.5f));
                collider.size = new Vector2(1, remap(time, 0, actTime, 1, 0));
            }
            if (!isOpen && time < 3) {
                //여는 연출
                Debug.Log("여는 연출");
                transform.position = new Vector2(old_pos.x, old_pos.y + remap(time, 0, 3f, 4, 0));
                collider.offset = new Vector2(0, remap(time, 0, actTime, -0.5f, 0));
                collider.size = new Vector2(1, remap(time, 0, actTime, 0, 1));

            }
        } else {
            if (isOpen && time < 3) {
                //닫는 연출
                Debug.Log("닫는 연출");
                transform.position = new Vector2(old_pos.x, old_pos.y - remap(time, 0, 3f, 0, 4f));
                collider.offset = new Vector2(0, remap(time, 0, actTime, 0, 0.5f));
                collider.size = new Vector2(1, remap(time, 0, actTime, 1, 0));
            }
            if (!isOpen && time < 3) {
                //여는 연출
                Debug.Log("여는 연출");
                transform.position = new Vector2(old_pos.x, old_pos.y - remap(time, 0, 3f, 4, 0));
                collider.offset = new Vector2(0, remap(time, 0, actTime, 0.5f, 0));
                collider.size = new Vector2(1, remap(time, 0, actTime, 0, 1));

            }
        }
        
    }
}