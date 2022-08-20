using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class ItemManager : MonoBehaviour {
    private AudioSource audio;
    private BoxCollider2D collider;
    private SpriteRenderer image;
    private void Start() {

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        AudioManager.Instance.PlaySFX(SFXType.Gain);
    }
}
