using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HueSwitch : MonoBehaviour{ 
    
    [Header("PostProcessing References")]    
    public VolumeProfile VolumeProfile;

    [Header("UnityEvent")]
    public UnityEvent OnHueSwitch;

    [Header("Dimension Colors")]
    [SerializeField] bool useColor1 = true; // Flag to toggle between DimensionColor1 and DimensionColor2

    [SerializeField] private Color activeColor;
    public Color DimensionColor1;
    public Color DimensionColor2;
    

    private void Start()
    {
        VolumeProfile.TryGet(out ColorAdjustments colorAdjustments);
        colorAdjustments.colorFilter.value = DimensionColor1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwapColor();
        }
    }

    public void SwapColor()
    {
        OnHueSwitch.Invoke();
        Debug.Log("Switched color");
        useColor1 = !useColor1; // Toggle the flag
        Color colorToApply = useColor1 ? DimensionColor1 : DimensionColor2;
        VolumeProfile.TryGet(out ColorAdjustments colorAdjustments);
        colorAdjustments.colorFilter.value = colorToApply;
    }
}
