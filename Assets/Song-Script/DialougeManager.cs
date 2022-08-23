using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class DialougeManager : Singleton<DialougeManager>
{
    public TextMeshProUGUI sentenceText;
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public readonly Queue<string> SentenceQueue = new Queue<string>();
    public GameObject arrow;

    [Header("타이핑 관련")]
    public float typingTime = 0.05f;

    private string _currentSentence;

    private Action _onDialogueEnd;

    public void OnDialogue(string[] lines, Action onDialogueEnd = null)
    {
        SentenceQueue.Clear();

        foreach (string line in lines)
        {
            SentenceQueue.Enqueue(line);
        }
        canvas.enabled = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        _onDialogueEnd = onDialogueEnd;
        
        // Todo:
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvas.enabled = false;
        _onDialogueEnd?.Invoke();
    }

    private IEnumerator Typing()
    { 
        var charArray = SentenceQueue.Dequeue().ToCharArray();
        var sb = new StringBuilder();
        
        foreach (var c in charArray)
        {
            sb.Append(c);
            sentenceText.text = sb.ToString();
            yield return new WaitForSeconds(typingTime);
        }
    }

    private IEnumerator CoUpdate()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Todo:
            }
        }
    }
}
