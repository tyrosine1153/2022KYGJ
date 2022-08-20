using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _characterTransform;
    private void Start()
    {
        _characterTransform = FindObjectOfType<CharacterController>().transform;
    }

    private void Update()
    {
        var pos = _characterTransform.position;
        pos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
