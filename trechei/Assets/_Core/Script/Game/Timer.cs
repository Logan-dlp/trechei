using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeInGame = 0;
    
    string DisplayTime(float _timeToDisplay)
    {
        if (_timeToDisplay < 0)
        {
            _timeToDisplay = 0;
        }

        float _minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float _seconds = Mathf.FloorToInt(_timeToDisplay % 60);
        float _milliseconds = _timeToDisplay % 1 * 1000;

        return string.Format("{0:00}:{1:00}:{2:000}", _minutes, _seconds, _seconds);
    }
}
