using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(() => SceneManagerEx.Instance.LoadScene(SceneType.Cinematic));
    }
}
