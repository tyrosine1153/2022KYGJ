using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Main,
    Cinematic,
    Stage1,
    Stage2,
    Stage3,
}

public class SceneManagerEx : Singleton<SceneManagerEx>
{
    public SceneType CurrentSceneType 
        => (SceneType)SceneManager.GetActiveScene().buildIndex;

    [SerializeField] private GameObject loadingPanel;
    private Animator _animator;
    private static readonly int FadeIn = Animator.StringToHash("FadeIn");
    private static readonly int FadeOut = Animator.StringToHash("FadeOut");

    protected override void Awake()
    {
        base.Awake();
        
        _animator = loadingPanel.GetComponent<Animator>();
        loadingPanel.SetActive(false);
    }

    public void LoadScene(SceneType sceneType, float loadingTime = 1.6f)
    {
        StartCoroutine(CoLoadScene(sceneType, loadingTime));
    }

    private IEnumerator CoLoadScene(SceneType sceneType, float loadingTime)
    {
        var op = SceneManager.LoadSceneAsync((int)sceneType);
        op.allowSceneActivation = false;

        loadingPanel.SetActive(true);
        _animator.SetTrigger(FadeIn);
        yield return new WaitForSeconds(1f);
        while (!op.isDone)
        {
            yield return new WaitForSeconds(loadingTime);

            op.allowSceneActivation = true;
        }
        _animator.SetTrigger(FadeOut);
        yield return new WaitForSeconds(0.5f);
        loadingPanel.SetActive(false);
        SceneLoadCallBack(sceneType);
    }

    private void SceneLoadCallBack(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Main:
                break;
            case SceneType.Cinematic:
                var canvas = FindObjectOfType<CinematicCanvas>();
                canvas.ShowText();
                break;
            case SceneType.Stage1:
                break;
            case SceneType.Stage2:
                break;
            case SceneType.Stage3:
                break;
        }
    }
}