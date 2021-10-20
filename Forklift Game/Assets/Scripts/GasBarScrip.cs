using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBarScrip : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SetMaxGas(int health)
    {
        slider.maxValue = health;
    }

    public void SetGas(int health)
    {
        slider.value = health;
    }
}
