using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBackground : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Image>().color = Settings.UI.MainBackground;
    }
}
