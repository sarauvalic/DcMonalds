﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
       Start, Resume, Pause, End, Restart
    }

    public GameState currentState;


    private Level level;

    private PlayerMovement playerMovement;
    private GameObject player;

    public UIController UIcontroller;
    public SceneController sceneController;

    private void Awake()
    {
        currentState = GameState.Start;

        playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.gameObject;
       
        level = FindObjectOfType<Level>();
    }

    private void Start()
    {
        playerMovement.SetBounds(0, level.GetNumberOfLanes());
        playerMovement.enabled = false;
        EnterState(currentState);
    }


    public void ChangeState(GameState newState)
    {
        ExitState(currentState);
        EnterState(newState);
    }


    private void EnterState(GameState gameState)
    {
        currentState = gameState;

        switch (gameState)
        {
            case GameState.Start:
                UIcontroller.HideAll();
                UIcontroller.Play();

                ChangeState(GameState.Resume);
                break;

            case GameState.Pause:
                UIcontroller.Pause();
                playerMovement.enabled = false;
                break;

            case GameState.Resume:
                playerMovement.enabled = true;

                break;

            case GameState.End:
                playerMovement.enabled = false;
                
                break;

            case GameState.Restart:
                sceneController.ReloadScene();
                break;
            default:
                break;
        }
    }
    

    private void ExitState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Start:
                
                break;

            case GameState.Resume:
                
                break;

            case GameState.Pause:
                UIcontroller.Unpause();
                break;

            case GameState.End:
              
                break;
            default:
                break;
        }
    }
}
