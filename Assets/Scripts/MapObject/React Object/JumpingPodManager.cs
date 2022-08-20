using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class JumpingPodManager : MonoBehaviour {
    public Sprite offImage;
    public Vector2 offSize;
    public Sprite onImage;
    public Vector2 onSize;
    public float force;
    public float disabledTime = 1;
    private float time = 0;
    void Start() {
        gameObject.name = "[Object] JumpingPod";
        //parent Object setting
        gameObject.GetComponent<RectTransform>().sizeDelta = offSize;
        gameObject.AddComponent<BoxCollider2D>(); {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = offSize;
        }
        gameObject.AddComponent<Image>();
        gameObject.GetComponent<Image>().sprite = offImage;
        //Child Object Setting
        GameObject child = new GameObject("JumpingPod Trigger");
        child.transform.parent = this.transform;
        child.AddComponent<RectTransform>(); {
            RectTransform rect = child.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.localPosition = new Vector2(
                0,
                onSize.y / 2
            ) ;
        }
        child.AddComponent<BoxCollider2D>(); {
            BoxCollider2D collider = child.GetComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new Vector2(
                onSize.x,
                onSize.y - offSize.y
            );
        }
        child.AddComponent<Image>(); {
            Image image = child.GetComponent<Image>();
            image.sprite = onImage;
            image.enabled = false;
        }
    }
    private void Update() {
        time += Time.deltaTime;
        if (time >= disabledTime) {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }
}
