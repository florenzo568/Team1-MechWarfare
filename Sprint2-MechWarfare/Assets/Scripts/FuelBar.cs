using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] Image Fuel;
    [SerializeField] Hover HoverCs;
    public float FuelAmount;
    public float FuelMax;
    void Start()
    {
        FuelMax = HoverCs.maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        FuelAmount = HoverCs.Fuel;
        Fuel.fillAmount = FuelAmount / FuelMax;
    }
}
