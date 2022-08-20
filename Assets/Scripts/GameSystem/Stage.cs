using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Transform startPoint;

    private void Start()
    {
        var player = FindObjectOfType<CharacterController>();
        player.transform.position = startPoint.position;
        DialougeManager.Instance.OnDialogue(StoryScripts.StageStart[0]);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (GameManager.Instance.savedStageId)
            {
                case 1:
                    if (GameManager.Instance.Quest.QuestProgress[1])
                    {
                        GameManager.Instance.StageClear();
                    }
                    else
                    {
                        DialougeManager.Instance.OnDialogue(new[] { "여기서 해야 할 일이 남아있는 것 같아" });
                    }
                    break;
                case 2:
                    break;
            }
        }
    }
}
