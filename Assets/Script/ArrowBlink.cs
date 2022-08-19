using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBlink : MonoBehaviour
{
	public float fadeTime;  // ���̵� �Ǵ� �ð�
	Image Img;  // ���̵� ȿ���� ���Ǵ� Image UI

	void Awake() => Img = GetComponent<Image>();

	//#Fade ȿ���� In -> Out ���� �ݺ��Ѵ�.
	void OnEnable() => StartCoroutine("FadeInOut");

	//#Fade ȿ���� In -> Out ���� �ݺ��Ѵ�.
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