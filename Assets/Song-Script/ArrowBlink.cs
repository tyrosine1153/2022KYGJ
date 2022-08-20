using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBlink : MonoBehaviour
{
	public float fadeTime;  // 페이드 되는 시간
	Image Img;  // 페이드 효과에 사용되는 Image UI

	void Awake() => Img = GetComponent<Image>();

	//#Fade 효과를 In -> Out 무한 반복한다.
	void OnEnable() => StartCoroutine("FadeInOut");

	//#Fade 효과를 In -> Out 무한 반복한다.
	void OnDisable() => StopCoroutine("FadeInOut");

	IEnumerator FadeInOut()
	{
		while (true)
		{
			yield return StartCoroutine(Fade(1, 0));    // Fade In

			yield return StartCoroutine(Fade(0, 1));    // Fade Out
		}
	}

	private IEnumerator Fade(float start, float end)
	{
		float current = 0;
		float percent = 0;

		while (percent < 1)
		{
			current += Time.deltaTime;
			percent = current / fadeTime;

			Color color = Img.color;
			color.a = Mathf.Lerp(start, end, percent);
			Img.color = color;

			yield return null;
		}
	}
}