using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    private bool _isStageClear;

    private void Start()
    {
        var player = FindObjectOfType<CharacterController>();
        player.transform.position = startPoint.position;
        if (GameManager.Instance.savedStageId == 1)
        {
            DialougeManager.Instance.OnDialogue(StoryScripts.StageStart[0]);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isStageClear)
        {
            other.tag = "Box";
            _isStageClear = true;
            GameManager.Instance.StageClear();
        }

        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.Quest.QuestProgress[2])
            {
                GameManager.Instance.StageClear();
            }
            else
            {
                DialougeManager.Instance.OnDialogue(new[] { "여기서 해야 할 일이 남아있는 것 같아" });
            }
        }
    }
}
