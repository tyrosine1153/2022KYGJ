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
        audio = GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("Audio/Effect/Drinking");
        collider = GetComponent<BoxCollider2D>();
        image = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        audio.Play();
        //TODO:
    }
}
