using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite() {
        // sr.sprite = newSprite;
        sr.color = Color.white;
    }
}
