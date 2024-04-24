using System;
using TMPro;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Transform levelHolder;

    public static float timer;
    public TMP_Text timerText;

    public AudioClip Orange, Blue;
    private AudioSource music => GetComponent<AudioSource>();

    private void Start()
    {
        timer = 0;
        LoadLevel(StaticData.CurrentLevel);
    }
    
    public void SetClip(bool isOrange)
    {
        music.clip = isOrange ? Blue : Orange;
        music.time = TimeCopy.time % music.clip.length;
        music.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        timerText.text = $"<mspace=1em>{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}</mspace>";
    }

    public void LoadLevel(int ID)
    {
        var l = levelHolder.childCount;
        for (int i = 0; i < l; i++)
        {
            levelHolder.GetChild(i).gameObject.SetActive(i == ID);
        }

        StaticData.CurrentLevel = ID;
    }
}