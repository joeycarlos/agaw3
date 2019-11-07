using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public Text scoreValue;

    void Update() {
        scoreValue.text = GameManager.Instance.score.ToString("F0");
    }
}
