using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI _instance;

    public static GameplayUI Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameplayUI");
                go.AddComponent<GameplayUI>();
            }

            return _instance;
        }
    }

    public Text scoreValue;

    public Text startPromptText;
    public Image startPromptBackground;

    void Awake() {
        _instance = this;
    }

    void Start() {
        StartCoroutine("CycleColor");
    }

    void Update() {
        scoreValue.text = GameManager.Instance.score.ToString("F0");
    }

    public void DisableStartPrompt() {
        startPromptText.enabled = false;
        startPromptBackground.enabled = false;
    }

    public void UpdateColour() {
        // sr.sprite = newSprite;
        // scoreValue.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        startPromptText.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    IEnumerator CycleColor() {
        while (true) {
            UpdateColour();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
