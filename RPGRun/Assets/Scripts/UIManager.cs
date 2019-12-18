﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 언제 어디서나 쉽게 접금할수 있도록 하기위해 만든 정적변수
    public static UIManager instance;
    public static bool boolgameOver;
    public Text playerName;
    public Text playerMoney;
    public Image playerHPBar;

    public Text gameOver;
    public GameObject button;

    Animator animGameOver;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        animGameOver = gameOver.gameObject.GetComponent<Animator>();
        boolgameOver = false;
        gameOver.enabled = false;
        button.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOver.enabled = true;
        boolgameOver = true;
        animGameOver.SetTrigger("show");
        button.SetActive(true);
    }

    public void UpdatePlayerUI(PlayerParams playerParams)
    {
        playerName.text = playerParams.name;
        playerMoney.text = "Score : " + playerParams.money.ToString();
        playerHPBar.rectTransform.localScale = 
            new Vector3((float)playerParams.curHp / (float)playerParams.maxHp, 1f, 1f);

    }
    void Update()
    {
    }
}
