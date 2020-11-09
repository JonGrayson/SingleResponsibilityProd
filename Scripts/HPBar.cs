using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged; //Null reference error 1

    }

    private void HandleHPPctChanged(float pct)
    {
        slider.value = pct;
    }
}
