using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private static GameOverUI _instance;

    public static GameOverUI Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameOverUI");
                go.AddComponent<GameOverUI>();
            }

            return _instance;
        }
    }

    public Text scoreValue;

    void Awake() {
        _instance = this;
    }

    void Update() {
        scoreValue.text = GameManager.Instance.score.ToString("F0");
    }
}
