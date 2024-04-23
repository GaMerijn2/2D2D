using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    public UnityEvent OnButtonPress;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (other.CompareTag("ButtonTopCollider"))
        {
            OnButtonPress.Invoke();
        }
    }
}
