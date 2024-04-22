using UnityEngine;

public class ColorConverter : MonoBehaviour
{
    public Color HexToRgb(string hex)
    {
        hex = hex.Replace("#", "");
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color(r /2, g/2, b/2, 255);
    }

    public Color ConvertToHex(string hex)
    {
        Color color = HexToRgb(hex);
        Debug.Log(color.ToString()); // Outputs converted color
        return color;
    }
}