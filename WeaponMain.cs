using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMain : MonoBehaviour
{
    //ADS Section
    [Header("ADS Parameters")]
    //---Float Values
    [SerializeField] private float adsSpeed;
    //---Vector Values
    [SerializeField] private Vector3 weaponHipPos;
    [SerializeField] private Vector3 weaponAimPos;

    void Start()
    {
        weaponHipPos = transform.localPosition;
    }

    void ADSLogic()
    {

        if(Input.GetButton("Fire2"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, weaponAimPos, adsSpeed * Time.deltaTime);
        }

        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, weaponHipPos, adsSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        ADSLogic();
    }
}
