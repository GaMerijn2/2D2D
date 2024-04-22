using System;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HueSwitch : MonoBehaviour{ 
    
    [Header("PostProcessing References")]    
    public VolumeProfile VolumeProfile;

    [Header("Dimension Colors")]
    [SerializeField] bool useColor1 = true; // Flag to toggle between DimensionColor1 and DimensionColor2

    [SerializeField] private Color activeColor;
    public Color DimensionColor1;
    public Color DimensionColor2;
    

    private void Start()
    {
        activeColor = DimensionColor1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        SwapColor();
        }
    }

    public void SwapColor()
    {
        Color colorToApply = useColor1 ? DimensionColor1 : DimensionColor2;
        useColor1 = !useColor1; // Toggle the flag
        VolumeProfile.TryGet(out ColorAdjustments colorAdjustments);
        colorAdjustments.colorFilter.value = colorToApply;
    }
}
