using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxManager : MonoBehaviour
{
    public Vector2 boxSize;
    public Sprite boxImage;
    void Start()
    {
        //Debug.Log(GetComponent<RectTransform>().position);
        //Debug.Log(transform.position);
        this.gameObject.tag = "Box";
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<RectTransform>().sizeDelta = boxSize;
        gameObject.AddComponent<Image>();
        if (boxImage == null)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Create");
        }
        else
        {
            GetComponent<Image>().sprite = boxImage;
        }
        gameObject.AddComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().size = boxSize;
    }
}
