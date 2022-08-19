using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    public string[] sentence;
        
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DialougeManager.Instance.OnDialogue(sentence);
        }
    }
}
