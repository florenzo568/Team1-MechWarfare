using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AmmoText;
    public Aim AmmoCS;
    public int AmmoCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AmmoCounter = AmmoCS.Ammo;
        AmmoText.text = AmmoCounter.ToString();
    }
}
