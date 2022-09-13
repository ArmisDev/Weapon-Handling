using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float smoothMult;

    void Start()
    {
        //orginPosition = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwayLogic();
    }

    void WeaponSwayLogic()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * smoothMult;
        float mouseY = Input.GetAxisRaw("Mouse Y") * smoothMult;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}