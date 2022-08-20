using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    private bool _isStageClear;

    private void Start()
    {
        var player = FindObjectOfType<CharacterController>();
        player.transform.position = startPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&!_isStageClear) {
            other.tag = "Box";
            _isStageClear = true;
            GameManager.Instance.StageClear();
        }
    }
}
