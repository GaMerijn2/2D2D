using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetActive(true);
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
