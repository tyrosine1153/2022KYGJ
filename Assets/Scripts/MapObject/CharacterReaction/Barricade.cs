using System.Collections;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private bool _isBroken;
    [SerializeField] private int health = 3;

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            Break();
        }
    }

    private void Break()
    {
        if (_isBroken) return;

        _isBroken = true;
        StartCoroutine(CoBreak());
    }

    private IEnumerator CoBreak()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
