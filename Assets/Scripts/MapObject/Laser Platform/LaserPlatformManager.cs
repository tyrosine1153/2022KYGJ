using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlatformManager : MonoBehaviour {
    public Vector2 platformSize;
    LineRenderer line;
    void Start() {
        
    }
    void Update() {
        line = GetComponent<LineRenderer>();
        MeshCollider collider = GetComponent<MeshCollider>();
        Mesh mesh = new Mesh();
        line.BakeMesh(mesh);
        collider.sharedMesh = mesh;
    }
}
