using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public int score;

    void Awake() {
        _instance = this;
    }

    void Start() {
        score = 0;
    }

    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // pause game
        // wait for player to press space
        // load GameOver overlay
        // reload scene OR esc to go to start screen
    }

    void Win() {
        // pause game
        // wait for player to press space
    }
}
