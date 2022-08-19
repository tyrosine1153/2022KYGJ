using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pendulumManager : MapObjectManager {
    [Range(0, 90f)] public float angle = 30;
    [Range(-10f, 10f)] public float angleVelocity = 0;

    public Sprite rodImage;
    public float rodLength = 0;
    public float rodThickness = 0;
    
    public Sprite bobImage;
    public float bobWidth = 0;
    public float bobHeight = 0;

    public Sprite anchorImage;
    public float anchorWidth = 0;
    public float anchorHeight = 0;

    private float time;
    void Start() {
        if (anchorImage != null) {
            gameObject.AddComponent<Image>();
        }
        /*Rod Create Code*/ {
            GameObject rod = new GameObject("Rod");
            rod.transform.parent = this.transform;
            rod.AddComponent<RectTransform>(); {
                RectTransform rect = rod.GetComponent<RectTransform>();
                rect.localScale = Vector3.one;
                rect.sizeDelta = new Vector2(rodThickness, rodLength);
                rect.localPosition = new Vector2(0, -rodLength / 2);
            }
            rod.AddComponent<Image>(); {
                Image image = rod.GetComponent<Image>();
                image.sprite = rodImage;
            }
        }
        /*Bob Create Code*/ {
            GameObject bob = new GameObject("bob");
            bob.transform.parent = this.transform.GetChild(0).transform;
            bob.AddComponent<RectTransform>(); {
                RectTransform rect = bob.GetComponent<RectTransform>();
                rect.localScale = Vector3.one;
                rect.sizeDelta = new Vector2(bobWidth, bobHeight);
                rect.localPosition = new Vector2(0, -rodLength / 2);
            }
            bob.AddComponent<Image>(); {
                
            }
        }
    }
    void Update() {
        time += Time.deltaTime * angleVelocity;
        transform.rotation = CalculateMovementOfPendulum();
    }
    Quaternion CalculateMovementOfPendulum() {
        return Quaternion.Lerp(Quaternion.Euler(Vector3.forward * angle),
            Quaternion.Euler(Vector3.back * angle), GetLerpTParam());
    }
    float GetLerpTParam() {
        return (Mathf.Sin(time) + 1) * 0.5f;
    }
}