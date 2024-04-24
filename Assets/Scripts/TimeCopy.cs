using System;
using UnityEngine;

public class TimeCopy : MonoBehaviour
{
    private static TimeCopy instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static float time;
    private void Update()
    {
        time += Time.deltaTime;
    }
}