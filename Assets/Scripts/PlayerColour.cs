using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColour : MonoBehaviour
{
    private SpriteRenderer sr;
    public float timeBetweenColor = 0.2f;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("CycleColor");
    }

    public void ChangeSprite() {
        // sr.sprite = newSprite;
        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    IEnumerator CycleColor() {
        while (true) {
            ChangeSprite();
            yield return new WaitForSeconds(timeBetweenColor);
        }
    }
}
