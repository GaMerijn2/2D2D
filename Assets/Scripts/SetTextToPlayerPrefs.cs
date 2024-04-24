using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextToPlayerPrefs : MonoBehaviour
{
    [SerializeField] private string prefsValue;
    
    void Start()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(prefsValue));
        GetComponent<TMP_Text>().text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}";
    }
}
