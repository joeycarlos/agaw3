using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isTriggered;
    public float timeBetweenColor;
    private SpriteRenderer sr;

    void Start() {
        isTriggered = false;
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update() {
    }

    public void ChangeSprite() {
        // sr.sprite = newSprite;
        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    IEnumerator CycleColor() {
        while(isTriggered)
        {
            ChangeSprite();
            yield return new WaitForSeconds(timeBetweenColor);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player" && isTriggered == false) {
            isTriggered = true;
            StartCoroutine("CycleColor");
        }
    }
}
