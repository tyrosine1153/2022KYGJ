using System;
using UnityEngine;

public class BackgroundsParallax : MonoBehaviour
{
    [SerializeField] private Transform[] imageTransform;
    [SerializeField] private float[] imageParallaxSpeed;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        if (imageTransform.Length != imageParallaxSpeed.Length)
        {
            Debug.LogError("imageTransform.Length != imageParallaxSpeed.Length");
        }
    }

    private void LateUpdate()
    {
        var deltaMovement = cameraTransform.position - lastCameraPosition;
        for (var i = 0; i < imageTransform.Length; i++)
        {
            var move = deltaMovement * imageParallaxSpeed[i];
            move.y = 0;
            imageTransform[i].position += move;
        }
        lastCameraPosition = cameraTransform.position;
    }
}