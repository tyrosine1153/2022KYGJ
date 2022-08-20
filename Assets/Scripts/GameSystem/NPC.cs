using UnityEngine;

public class NPC : MonoBehaviour
{
    public int scriptId;
    private bool isTalking;

    public void Talk()
    {
        if (isTalking) return;
        isTalking = true;

        switch (scriptId)
        {
            case 1:
                DialougeManager.Instance.OnDialogue(StoryScripts.NPCTalk[scriptId], () =>
                {
                    GameManager.Instance.Quest.OpenQuest(1);
                    // 퀘스트 ui
                    gameObject.SetActive(false);
                    isTalking = false;
                });
                break;
            case 2:
                GameManager.Instance.Quest.ClearQuest(1);
                DialougeManager.Instance.OnDialogue(StoryScripts.NPCTalk[scriptId], () =>
                {
                    // 퀘스트 UI
                    var s = StoryScripts.QuestReward[1];
                    isTalking = false;
                });
                break;
            case 3:
                DialougeManager.Instance.OnDialogue(StoryScripts.NPCTalk[scriptId], () =>
                {
                    GameManager.Instance.Quest.OpenQuest(2);
                    isTalking = false;
                });
                break;
        }
    }
}
