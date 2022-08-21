using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public List<Image> HP_Img = new List<Image>();
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button button;

    void Update()
    {
        HP_Check();
    }

    void HP_Check()
    {
        var character = FindObjectOfType<CharacterController>().hp;
        Debug.Log(character);

        switch(character)
        {
            case 0:
                break;

            case 1:
                HP_Img[0].enabled = true;
                HP_Img[1].enabled = false;
                HP_Img[2].enabled = false;
                HP_Img[3].enabled = false;
                break;

            case 2:
                HP_Img[0].enabled = true;
                HP_Img[1].enabled = true;
                HP_Img[2].enabled = false;
                HP_Img[3].enabled = false;
                break;

            case 3:
                HP_Img[0].enabled = true;
                HP_Img[1].enabled = true;
                HP_Img[2].enabled = true;
                HP_Img[3].enabled = false;
                break;

            case 4:
                HP_Img[0].enabled = true;
                HP_Img[1].enabled = true;
                HP_Img[2].enabled = true;
                HP_Img[3].enabled = true;
                break;


        }
    }
}
