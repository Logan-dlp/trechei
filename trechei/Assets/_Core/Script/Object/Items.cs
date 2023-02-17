using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            timer.TimeInGame -= 10;
            Destroy(gameObject);
        }
    }
    
}
