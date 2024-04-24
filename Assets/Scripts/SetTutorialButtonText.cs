using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTutorialButtonText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = $"Press '{StaticData.DimensionSwitchKey}' to switch dimensions";
    }
}