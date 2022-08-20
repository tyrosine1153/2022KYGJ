using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorManager : MonoBehaviour {
    public Direction direction;
    public enum Direction {
        RightUp, LeftUp
    }

    void Start() {
        GameObject laser = new GameObject("Laser");
        laser.transform.parent = this.transform;
        

    }
    void Update() {
        
    }
    public void DrawLaser(Vector2 inputUnitVector) {
        
    }
}
