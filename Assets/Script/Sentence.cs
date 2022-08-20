using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    public string[] sentence;

    void Start()
    {
        DialougeManager.Instance.OnDialogue(sentence);
    }
}
