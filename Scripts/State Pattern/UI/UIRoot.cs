﻿using System;
using UnityEngine;

/// <summary>
/// UI Root class, used for storing references to UI views.
/// </summary>
public class UIRoot : MonoBehaviour
{
    [SerializeField]
    private MenuView menuView;
    public MenuView MenuView => menuView;

    [SerializeField]
    private GameView gameView;
    public GameView GameView => gameView;

    [SerializeField]
    private PauseView pauseView;
    public PauseView PauseView => pauseView;

    [SerializeField]
    private GameOverView gameOverView;
    public GameOverView GameOverView => gameOverView;

    private void Awake()
    {
        MenuView.HideView();
        GameView.HideView();
        PauseView.HideView();
        GameOverView.HideView();
    }
}