using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class MovingSawManager : MonoBehaviour {
    
    [Range(0, 15f)] public float speed = 5;
    public Sprite lineImage;
    public Position sawStartPosition;
    public Sprite sawImage;
    public float length = 0;
    public float height = 0;
    public float radius = 0;
    public Half usingSpot;

    public enum Half {
        Upper, Lower
    }
    public enum Position { Left, Right, Center }
    Rigidbody2D rigid; RectTransform rect;
    void Start() {
        this.gameObject.name = "[Obstacle] Moving Saw Parent";
        if (lineImage != null) {
            this.gameObject.AddComponent<Image>();
            this.gameObject.GetComponent<Image>().sprite = lineImage;
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(length, height);
        }
        /*ChainSaw Create*/ {
            GameObject saw = new GameObject("Moving Saw"); saw.SetActive(false);
            saw.transform.parent = this.transform;
            saw.AddComponent<RectTransform>(); {
                RectTransform rect = saw.GetComponent<RectTransform>();
                rect.localScale = Vector3.one;
                switch (sawStartPosition) {
                    case Position.Left: rect.localPosition = new Vector2(-length / 2, 0); direction = 1; break;
                    case Position.Center: rect.localPosition = Vector2.zero; direction = 1; break;
                    case Position.Right: rect.localPosition = new Vector2(length / 2, 0); direction = -1; break;
                }
                rect.sizeDelta = new Vector2(radius * 2, radius * 2);
            }
            saw.AddComponent<Animation>(); {
                Animation animation = saw.GetComponent<Animation>();
                animation.clip = Resources.Load<AnimationClip>("Animation/Button/rotation");
                animation.Play();
            }
            saw.AddComponent<Rigidbody2D>(); {
                Rigidbody2D rigid = saw.GetComponent<Rigidbody2D>();
                rigid.drag = 0;
                rigid.angularDrag = 0;
                rigid.gravityScale = 0;
            }
            saw.AddComponent<Image>(); {
                Image image = saw.GetComponent<Image>();
                image.sprite = sawImage;
            }
            saw.AddComponent<BoxCollider2D>(); {
                BoxCollider2D collider = saw.GetComponent<BoxCollider2D>();
                collider.offset = new Vector2(0, usingSpot == Half.Upper ? radius / 2 : -radius / 2);
                collider.size = new Vector2(radius * 2, radius);
            }
            saw.SetActive(true);
            rigid = saw.GetComponent<Rigidbody2D>();
            rect = saw.GetComponent<RectTransform>();
        }
    }
    int direction = 1;
    void Update() {
        rect.localPosition = new Vector2(Mathf.Clamp(rect.localPosition.x, -length / 2, length / 2), 0);
        if (rect.localPosition.x <= -length / 2 && direction == -1) { direction = 1; }
        if (rect.localPosition.x >= length / 2 && direction == 1) { direction = -1; }
        rigid.velocity = new Vector2(direction * speed, 0);
    }
}
