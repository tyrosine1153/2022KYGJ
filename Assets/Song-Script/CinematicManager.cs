using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CinematicManager : MonoBehaviour
{
    public TextMeshProUGUI Sentence_Txt;
    public List<string> sentence = new List<string>();

    IEnumerator Start()
    {
        Sentence_Txt.text = sentence[0].ToString();

        yield return new WaitForSeconds(3f);

        Sentence_Txt.text = sentence[1].ToString();

        yield return new WaitForSeconds(3f);

        Sentence_Txt.text = sentence[2].ToString();

        yield return new WaitForSeconds(3f);

        Sentence_Txt.text = sentence[3].ToString();

        yield return new WaitForSeconds(3f);

        LoadingController.LoadScene("Stage1");
    }
}
