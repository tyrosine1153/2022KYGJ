using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI sentence_txt;
    public TextMeshProUGUI Name_Txt;
    public CanvasGroup CG;
    public Canvas Cvs;
    public Queue<string> sentence = new Queue<string>();
    public GameObject Arrow;

    [Header("Ÿ���� ����")]
    [HideInInspector] public bool istyping;
    public float Typing_Time = 0.05f;

    string currnetSentence;

    #region #�̱���
    public static DialougeManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void OnDialogue(string[] lines)
    {
        sentence.Clear();

        foreach (string line in lines)
        {
            sentence.Enqueue(line);
            istyping = true;
        }
        CG.alpha = 1;
        CG.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentence.Count != 0)
        {
            //#��ȭ�� �������� ��
            currnetSentence = sentence.Dequeue();
            Cvs.enabled = true;
            CG.alpha = 1;
            istyping = true;
            StartCoroutine(Typing(currnetSentence));
        }
        else
        {
            //#��� ��ȭ�αװ� ������ ��
            CG.alpha = 0;
            CG.blocksRaycasts = false;
            Cvs.enabled = false;
        }
    }

    IEnumerator Typing(string line)
    {
        sentence_txt.text = "";

        foreach (char letter in line.ToCharArray())
        {
            sentence_txt.text += letter;
            yield return new WaitForSeconds(Typing_Time);
        }

        Arrow.SetActive(true);
    }

    void Update()
    {
        if (sentence_txt.text.Equals(currnetSentence))
            istyping = false;

        OnNextClick();
    }

    public void OnNextClick()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (istyping == false)
            {
                NextSentence();
                Arrow.SetActive(false);
            }
        }
    }
}
