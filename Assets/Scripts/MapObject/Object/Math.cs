using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mathmatics {
    public static Vector2 directionUnitVector(Vector2 direction) {
        return Vector2.ClampMagnitude(direction * 100, 1);
    }
    public static Vector3 directionUnitVector(Vector3 direction) {
        return Vector3.ClampMagnitude(direction * 100, 1);
    }
    public static float Map(float value, float input1, float input2, float output1, float output2) {
        return output1 + (value - input1) * (output2 - output1) / (input2 - input1);
    }
    public static byte Map(float value, float input1, float input2) {
        return (byte) (0 + (value - input1) * 255 / (input2 - input1));
    }
}