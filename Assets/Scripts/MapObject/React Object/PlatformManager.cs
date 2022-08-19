using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformManager : MonoBehaviour {
    public bool isbreaking = false;
    public float recoverTime = 0;
    public Direction direction;
    public float length = 0;
    public float speed = 0;
    public enum Direction {None, Up_Down, Left_Right, RightUp_LeftDown, LeftUp_RightDown}
    public Sprite platformImage;
    public Vector2 platformSize;

    private Dictionary<Direction, Vector2> unitVector = new Dictionary<Direction, Vector2>() {
        {Direction.None, Vector2.zero}, {Direction.Up_Down, Vector2.up},
        {Direction.Left_Right, Vector2.right}, {Direction.LeftUp_RightDown, Vector2.up}
    };
    void Start() {
        GetComponent<RectTransform>().sizeDelta = platformSize;
        GetComponent<Image>().sprite = platformImage;
    }
    void Update() {
        
    }
}
