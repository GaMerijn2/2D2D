using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string LevelName;
    public Vector2 SpawnPos;

    private int _currentDimension = -1;

    private void Start()
    {
        SwitchDimensions(0);
    }

    private void SwitchDimensions(int dimension)
    {
        if (_currentDimension == dimension) return;
        
        _currentDimension = dimension;
        int l = transform.childCount;
        for (int i = 0; i < l; i++)
        {
           SetDimensionActive(transform.GetChild(i).gameObject, i == dimension);
        }
    }
    
    public static void SetDimensionActive(GameObject dimension, bool value)
    {
        foreach (var collider in dimension.GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = value;
        }
        
        foreach (var rbs in dimension.GetComponentsInChildren<Rigidbody2D>())
        {
            rbs.bodyType = value ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
        }
        
        foreach (var sld in dimension.GetComponentsInChildren<SliderJoint2D>())
        {
            sld.enabled = value;
        }

        foreach (var sprite in dimension.GetComponentsInChildren<SpriteRenderer>())
        {
            var color = sprite.color;
            sprite.color = new Color(color.r, color.g, color.b, value ? 1 : 0.5f);
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(StaticData.DimensionSwitchKey)) SwitchDimensions(_currentDimension == 0 ? 1 : 0);
        if (Input.GetMouseButtonDown(0)) SwitchDimensions(_currentDimension == 0 ? 1 : 0);
    }
}