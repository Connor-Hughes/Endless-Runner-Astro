﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    public Text scoreText = null;
    int score = 0;

    void Awake()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("gameData");

        if (gd.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        singleton = this;

        PlayerPrefs.SetInt("score", 0);
    }

    public void UpdateScore(int s)
    {
        score += s;
        PlayerPrefs.SetInt("score", score);
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("HighScore Change");
        }
    }

}
