using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Transform startPoint;

    private void Start()
    {
        var player = FindObjectOfType<CharacterController>();
        player.transform.position = startPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // GameManager.Instance.StageClear();
        }
    }
}
