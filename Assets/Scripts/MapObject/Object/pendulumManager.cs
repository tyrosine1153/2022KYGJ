using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PendulumManager : MapObjectManager {
    public float invokeTime = 0;
    [Range(0, 90f)] public float angle = 30;
    [Range(-10f, 10f)] public float angleVelocity = 0;
    public Sprite rodImage;
    public float rodLength = 0;
    public float rodThickness = 0;
    public Sprite bobImage;
    public Vector2 bobSize;
    public Sprite anchorImage;
    public Vector2 anchorSize;

    private float time; private bool active = false;
    void Start() {
        this.gameObject.name = "Pendulum Parent";
        if (anchorImage != null) {
            gameObject.AddComponent<Image>(); {
                Image image = GetComponent<Image>();
                image.sprite = anchorImage;
            }
            GetComponent<RectTransform>().sizeDelta = anchorSize;
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
                rect.sizeDelta = bobSize;
                rect.localPosition = new Vector2(0, -rodLength / 2);
            }
            bob.AddComponent<Image>(); {
                Image image = bob.GetComponent<Image>();
                image.sprite = bobImage;
            }
            bob.AddComponent<BoxCollider2D>(); {
                BoxCollider2D collider = bob.GetComponent<BoxCollider2D>();
                collider.isTrigger = true;
                collider.size = bobSize;
            }
        }
        Invoke("Actvie", invokeTime);
    }
    void Update() {
        if (active) {
            time += Time.deltaTime * angleVelocity;
            transform.rotation = CalculateMovementOfPendulum();
        }
    }
    private void Actvie() { active = true; }
    Quaternion CalculateMovementOfPendulum() {
        return Quaternion.Lerp(Quaternion.Euler(Vector3.forward * angle),
            Quaternion.Euler(Vector3.back * angle), GetLerpTParam());
    }
    float GetLerpTParam() {
        return (Mathf.Sin(time) + 1) * 0.5f;
    }
}