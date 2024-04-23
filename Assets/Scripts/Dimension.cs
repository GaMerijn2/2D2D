using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    [Header("References")]
    private HueSwitch hueSwitch;

    [SerializeField] private bool switchDimension;

    private void Start()
    {
        hueSwitch = GameObject.Find("HueShifter").GetComponent<HueSwitch>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && switchDimension)
        {
            SetActive(false);
            hueSwitch.SwapColor();
            switchDimension = !switchDimension;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !switchDimension)
        {
            SetActive(true);
            hueSwitch.SwapColor();
            switchDimension = !switchDimension;
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
            sprite.color = new Color(color.r, color.g, color.b, value ? 1 : (StaticData.DoesLevelFullyDisappear ? 0 : 0.5f));
        }
    }
}
