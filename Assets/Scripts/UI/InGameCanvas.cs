using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvas : Singleton<InGameCanvas>
{
    [SerializeField] private Image[] hpImg;
    [SerializeField] private GameObject diePanel;
    [SerializeField] private Button restartBtn;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button button;
    private TextMeshProUGUI _questText;

    public string QuestName
    {
        get => _questText.text;
        set => _questText.text = value;
    }

    public int Hp
    {
        set
        {
            for (int i = 0; i < hpImg.Length; i++)
            {
                hpImg[i].enabled = i < value;
            }
        }
    }

    public void Show(string description)
    {
        textMeshProUGUI.text = description;
        panel.SetActive(true);
        button.onClick.AddListener(() => { panel.SetActive(false); });
    }

    public void ShowOnDie()
    {
        diePanel.SetActive(true);
        restartBtn.onClick.AddListener(() => { SceneManagerEx.Instance.LoadScene(SceneType.Main); });
    }
}
