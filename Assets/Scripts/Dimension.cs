using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    private HueSwitch hueSwitch;

    private void Start()
    {
        hueSwitch = GameObject.Find("HueShifter").GetComponent<HueSwitch>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SetActive(false);
            hueSwitch.SwapColor();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SetActive(true);
            hueSwitch.SwapColor();
        }
    }

    public void SetActive(bool value)
    {
        foreach (var collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = value;
        }

        foreach (var sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            var color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, value ? 1 : 0.5f);
        }
    }
}
