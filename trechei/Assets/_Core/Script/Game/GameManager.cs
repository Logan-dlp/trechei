using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer Timer;
    [SerializeField] private Text timer;

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
        Timer.TimeInGame += Time.deltaTime;
        timer.text = Timer.DisplayTime(Timer.TimeInGame);
    }
}
