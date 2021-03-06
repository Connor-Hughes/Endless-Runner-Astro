﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject[] Panels;
    GameObject[] mmButtons;
    private int maxLives = 3;

    void Start()
    {
        Panels = GameObject.FindGameObjectsWithTag("subPanel");
        mmButtons = GameObject.FindGameObjectsWithTag("mmButton");

        foreach (GameObject p in Panels)
        {
            p.SetActive(false);
        }
    }

    public void ClosePanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject b in mmButtons)
        {
            b.SetActive(true);
        }
    }

    public void OpenPanel(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject b in mmButtons)
            if (b != button.gameObject)
            {
                b.SetActive(false);
            }
    }

    public void LoadGameScene()
    {
        PlayerPrefs.SetInt("lives", maxLives);
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }
}
