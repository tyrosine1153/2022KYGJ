using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class MovingPlatformManager : PlatformManager {
    public float length = 0;
    public Direction direction;
    public enum Direction {None, Up_Down, Left_Right, RightUp_LeftDown, LeftUp_RightDown}
    private Dictionary<Direction, Vector2> unitVector = new Dictionary<Direction, Vector2>() {
        {Direction.None, Vector2.zero}, 
        {Direction.Up_Down, Vector2.up},
        {Direction.Left_Right, Vector2.right}, 
        {Direction.LeftUp_RightDown, Vector2.ClampMagnitude(new Vector2(-1, 1), 1)},
        {Direction.RightUp_LeftDown, Vector2.ClampMagnitude(new Vector2(1, 1), 1)}
    };
    private Rigidbody2D rigid;
    private RectTransform rect;
    private Transform trans;
    protected override void OnStart() {
        gameObject.name = "[Platform] Moving Platform";
        GameObject platform = new GameObject("Platform");
        platform.transform.parent = this.transform;
        platform.SetActive(false);
        platform.AddComponent<RectTransform>();
        {
            rect = platform.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.localPosition = Vector2.zero;
            rect.sizeDelta = platformSize;
        }
        platform.AddComponent<BoxCollider2D>();
        {
            BoxCollider2D collider = platform.GetComponent<BoxCollider2D>();
            collider.size = platformSize;
        }
        platform.AddComponent<Rigidbody2D>();
        {
            rigid = platform.GetComponent<Rigidbody2D>();
            rigid.drag = 0;
            rigid.angularDrag = 0;
            rigid.gravityScale = 0;
            rigid.freezeRotation = true;
        }
        platform.AddComponent<PlatformCollider>();
        trans = platform.transform;
        platform.AddComponent<PlatformCollider>();
        platform.AddComponent<Image>();
        platform.GetComponent<Image>().sprite = platformImage;
        platform.SetActive(true);
        velocity = unitVector[direction];
    }
    protected override void OnUpdate() {
        rect.localPosition = Vector2.ClampMagnitude(rect.localPosition, length / 2);
        if (rect.localPosition.magnitude >= length / 2) {
            velocity = -velocity;
        }
        rigid.velocity = velocity * speed;
    }
    Vector2 velocity;
}
