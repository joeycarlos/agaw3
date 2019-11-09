using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    public Text gameTitle;

    void Start() {
        StartCoroutine("CycleColor");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
    }

    public void UpdateColour() {
        gameTitle.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    IEnumerator CycleColor() {
        while (true) {
            UpdateColour();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
