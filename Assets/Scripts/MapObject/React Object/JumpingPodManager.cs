using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class JumpingPodManager : MonoBehaviour {
    public AnimationClip animation;
    public Vector2 offSize;
    public Vector2 onSize;
    public float force;
    public float disabledTime = 1;
    private float time = 0;
    void Start() {
        
    }
    void Update() {
       
    }
}
