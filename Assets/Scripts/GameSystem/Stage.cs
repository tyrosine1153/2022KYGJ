using UnityEngine;

public class Stage : MonoBehaviour
{
    private bool _isStageClear;

    private void Start()
    {
        if (GameManager.Instance.savedStageId == 1)
        {
            DialougeManager.Instance.OnDialogue(StoryScripts.StageStart[0]);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isStageClear)
        {
            if (GameManager.Instance.Quest.QuestProgress[GameManager.Instance.savedQuestId - 1])
            {
                _isStageClear = true;
                GameManager.Instance.StageClear();
            }
            else
            {
                DialougeManager.Instance.OnDialogue(new[] { "여기서 해야 할 일이 남아있는 것 같아" });
            }
        }
    }
}
