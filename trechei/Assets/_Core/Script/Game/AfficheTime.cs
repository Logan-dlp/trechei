using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheTime : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private Text text;

    private void Start()
    {
        text.text = timer.DisplayTime(timer.Get());
    }
}
