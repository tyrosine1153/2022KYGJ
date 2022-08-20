using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformManager : PlatformManager {
    protected override void OnStart() {
        gameObject.name = "[Platform] Rotating Platform";
    }
    protected override void OnUpdate() {transform.Rotate(0, 0, -speed);}
}