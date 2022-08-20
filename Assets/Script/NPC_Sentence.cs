using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Sentence : MonoBehaviour
{
    public string[] sentence;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                DialougeManager.Instance.OnDialogue(sentence);
            }
        }
    }
}
