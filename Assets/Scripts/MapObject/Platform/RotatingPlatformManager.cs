using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformManager : PlatformManager {
    private BoxCollider2D collider;
    protected override void OnStart() {
        gameObject.AddComponent<BoxCollider2D>(); {
            collider = GetComponent<BoxCollider2D>();
            collider.size = platformSize;
        }
        gameObject.tag = "Ground";
        gameObject.name = "[Platform] Rotating Platform";
    }
    protected override void OnUpdate() {transform.Rotate(0, 0, -speed);}
}