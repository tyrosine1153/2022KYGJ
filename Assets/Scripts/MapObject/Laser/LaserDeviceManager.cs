using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LaserDeviceManager : MonoBehaviour {
    public Direction direction;
    public Sprite laserDeviceImage;
    public Vector2 laserDeviceSize;
    public float laserThickness;
    public Sprite laserImage;
    public float maxDistance;
    public enum Direction {
        Up, Right, Left, Down
    }
    private RectTransform laserRect, rect;
    private Dictionary<Direction, Vector2> unitVector = new Dictionary<Direction, Vector2>() {
        {Direction.Up, Vector2.up}, {Direction.Down, Vector2.down}, 
        {Direction.Left, Vector2.left}, {Direction.Right, Vector2.right}
    };
    void Start() {
        /*Laser Device Setting*/ {
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = laserDeviceSize;
        }
        gameObject.AddComponent<Image>(); {
            Image image = GetComponent<Image>();
            image.sprite = laserDeviceImage;
        }
        GameObject laser = new GameObject("Laser");
        laser.transform.parent = this.transform;
        laser.AddComponent<RectTransform>();
        rect = laser.GetComponent<RectTransform>();

    }
    void Update() {
        RaycastHit2D ray = Physics2D.Raycast(GetComponent<RectTransform>().localPosition, unitVector[direction], maxDistance);
        if (ray.collider != null) {
            switch (direction) {
            }
            switch (ray.collider.gameObject.tag) {
                case "Mirror": ray.collider.GetComponent<MirrorManager>().DrawLaser(unitVector[direction]); break;
                case "Player":
                    if (ray.collider.GetComponent<CharacterController>().CurrentCharacter != Chracter.Scarecrow) {
                        ray.collider.GetComponent<CharacterController>().GetDamage();
                    }
                    break;
            }
        }
    }
}
