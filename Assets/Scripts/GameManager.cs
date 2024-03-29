﻿using System.Collections;
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

    public float score;
    public bool gameIsRunning;
    public bool gameHasEnded;

    private AudioSource audioSource;

    void Awake() {
        _instance = this;
    }

    void Start() {
        score = 0;
        gameIsRunning = false;
        gameHasEnded = false;
        GameOverUI.Instance.gameObject.SetActive(false);
        WinUI.Instance.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (gameIsRunning) {
            score += Time.deltaTime * 10.0f;
        }
        else if (gameHasEnded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameIsRunning = true;
                GameplayUI.Instance.DisableStartPrompt();
                PlayerController p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                p.EnableGravity();
                audioSource.Play();
            }
        }
    }

    public void AddScore(float scoreToAdd) {
        score += scoreToAdd;
    }

    public void GameOver() {
        gameIsRunning = false;
        gameHasEnded = true;
        GameplayUI.Instance.gameObject.SetActive(false);
        GameOverUI.Instance.gameObject.SetActive(true);
        // Disable UI
        // pause game
        // wait for player to press space
        // load GameOver overlay
        // reload scene OR esc to go to start screen
    }

    public void Win() {
        gameIsRunning = false;
        gameHasEnded = true;
        WinUI.Instance.gameObject.SetActive(true);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // pause game
        // wait for player to press space
    }
}
