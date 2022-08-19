using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class SeeSawManager : MonoBehaviour {
    public Vector2 FulcrumSize;
    public Sprite FulcrumImage;
    public Vector2 leverSize;
    public Sprite leverImage;

    private Rigidbody2D parentRigid;
    private RectTransform parentRect, rect;
    void Start() {
        this.gameObject.name = "SeeSaw Lever";
        //Parent [Lever] Setting
        gameObject.AddComponent<Rigidbody2D>(); {
            parentRigid = GetComponent<Rigidbody2D>();
            parentRigid.drag = 0;
            parentRigid.angularDrag = 0;
            parentRigid.gravityScale = 0;
            parentRigid.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        parentRect = GetComponent<RectTransform>(); {
            parentRect.sizeDelta = leverSize;
        }
        this.gameObject.AddComponent<Image>();
        this.gameObject.GetComponent<Image>().sprite = leverImage;
        gameObject.AddComponent<BoxCollider2D>(); {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = leverSize;
        }
        //Child [Fulcrum] Setting
        GameObject child = new GameObject("SeeSaw Fulcrum");
        child.transform.parent = this.transform;
        child.AddComponent<RectTransform>(); {
            rect = child.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.localPosition = new Vector2(0, -FulcrumSize.y / 2);
            rect.sizeDelta = FulcrumSize;
        }
        child.AddComponent<Image>();
        child.GetComponent<Image>().sprite = FulcrumImage;
    }
    void Update()
    {
        
    }
}
