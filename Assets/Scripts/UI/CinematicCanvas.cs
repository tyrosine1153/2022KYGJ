using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class CinematicCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;

    private static readonly string[] Dialog = 
    {
        "금발머리에 통통하고 붉은 볼을 가진 귀여운 소녀가 있었습니다.\n" +
        "풀도 나무도 온통 회색빛인 슬슬한 마을에서 \n" +
        "숙부, 숙모와 함께 행복하게\n" +
        "살고 있었습니다.\n" +
        "그러던 어느날 도로시는 회오리바람에 집이 통채로 날라갔습니다.\n" +
        "도로시는 예쁜 꽃과 따뜻한 햇볕이 가득한 아름다운 나라, 오즈에 도착하였습니다.",
        "도로시: 으아아악 살려줘~ 토토야 꽉잡아!!",
        "토토: 망망!!",
        "회오리 바람은 도로시와 토토를 예쁜 꽃과 따뜻한 햇볕이 가득한 \n" +
        "아름다운 나라로 데려갔습니다",
    };
    
    private int _currentDialogueIndex = 0;
    private Coroutine _dialogueCoroutine;
    
    private void Start()
    {
        StartCoroutine(CoUpdate());
    }

    private IEnumerator CoUpdate()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NextDialogue();
                Debug.Log("E");
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }

    public void ShowText()
    {
        _dialogueCoroutine = StartCoroutine(CoShowText(Dialog[_currentDialogueIndex]));
    }

    private IEnumerator CoShowText(string dialog)
    {
        var charArray = dialog.ToCharArray();
        var sb = new StringBuilder();
        
        foreach (var c in charArray)
        {
            sb.Append(c);
            dialogueText.text = sb.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        _currentDialogueIndex++;
        _dialogueCoroutine = null;
    }

    private void NextDialogue()
    {
        if (_dialogueCoroutine != null)
        {
            StopCoroutine(_dialogueCoroutine);
            dialogueText.text = Dialog[_currentDialogueIndex];
            _dialogueCoroutine = null;
            _currentDialogueIndex++;
            return;
        }
        
        if (_currentDialogueIndex >= Dialog.Length)
        {
            SceneManagerEx.Instance.LoadScene(SceneType.Stage1);
            GameManager.Instance.GameStart();
        }
        else
        {
            ShowText();
        }
    }
}
