using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer Timer;
    [SerializeField] private Text timer;
    public float Score;
    public bool InGame = false;

    public void CursorInGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorOutGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (InGame == true)
        {
            Timer.TimeInGame += Time.deltaTime;
        }
        if (Timer.TimeInGame <= 0)
        {
            Timer.TimeInGame = 0;
        }
        timer.text = Timer.DisplayTime(Timer.TimeInGame);
    }
}
