using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleClick : MonoBehaviour
{
    public Image FadeOut_Img;
    float T;

    public void Title_Click() => StartCoroutine(FadeFlow());

    IEnumerator FadeFlow()
    {
        FadeOut_Img.gameObject.SetActive(true);

        Color alpha = FadeOut_Img.color;

        while (alpha.a < 1f)
        {
            T += Time.deltaTime;
            alpha.a = Mathf.Lerp(0, 1, T);
            FadeOut_Img.color = alpha;

            yield return null;
        }

        if (alpha.a == 1)
            SceneManager.LoadScene("Cinematic");
    }
}
