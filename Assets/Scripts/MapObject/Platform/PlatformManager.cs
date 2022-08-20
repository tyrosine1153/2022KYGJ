using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
    public bool isbreaking = false;
    public float breakTime = 2;
    public float recoverTime = 3;
    public float speed = 0;
    public Sprite platformImage;
    public Vector2 platformSize;
    protected virtual void OnStart() {}
    void Start() {OnStart();}
    protected virtual void OnUpdate() {}
    void Update() {OnUpdate();}
}
