using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    private static WinUI _instance;

    public static WinUI Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("WinUI");
                go.AddComponent<WinUI>();
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
