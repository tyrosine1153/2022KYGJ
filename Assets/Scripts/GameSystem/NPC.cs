using UnityEngine;

public enum ScriptType
{
    Normal,
    QuestOpen,
    QuestEnd,
}

public class NPC : MonoBehaviour
{
    public int scriptId;
    public ScriptType ScriptType;
    private bool isTalking;

    public void TalkStart()
    {
        if (isTalking) return;
        isTalking = true;

        switch (ScriptType)
        {
            case ScriptType.QuestOpen:
                DialougeManager.Instance.OnDialogue(StoryScripts.QuestStart[scriptId], () =>
                {
                    GameManager.Instance.Quest.OpenQuest(scriptId);
                    TalkEnd();
                });
                break;
            case ScriptType.QuestEnd:
                DialougeManager.Instance.OnDialogue(StoryScripts.QuestEnd[scriptId], () =>
                {
                    GameManager.Instance.Quest.ClearQuest(scriptId);
                    TalkEnd();
                });
                break;
            case ScriptType.Normal:
                DialougeManager.Instance.OnDialogue(StoryScripts.NormalNPCTalk[scriptId], TalkEnd);
                break;
        }
    }

    private void TalkEnd()
    {
        gameObject.SetActive(false);
        isTalking = false;
    }
}
