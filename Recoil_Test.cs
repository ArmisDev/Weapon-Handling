using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil_Test : MonoBehaviour
{

    public MouseLook mouseLookScript;

    public bool isFiring;

    public bool isAutomatic;

    public float currentRecoilZPos;
    private float recoilAmount_z = 0.5f;

    public float currentRecoilXPos;
    private float recoilAmount_x = 0.5f;

    public float currentRecoilYPos;
    private float recoilAmount_y = 0.9f;

    public float gunPrecision;
    
    void Start()
    {
        //isFiring = false;
    }

    void Update()
    {
        RecoilMath();
    }

    public void RecoilMath()
    {
        if(!isAutomatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                currentRecoilZPos -= recoilAmount_z;
                currentRecoilXPos -= (Random.value - 0.3f) * recoilAmount_x;
                currentRecoilYPos -= (Random.value - 0.9f) * recoilAmount_y;
                mouseLookScript.currentMouseDelta.y += Mathf.Abs(currentRecoilYPos * gunPrecision);
                mouseLookScript.currentMouseDelta.x -= (currentRecoilXPos * gunPrecision);
            }

            else
            {
                currentRecoilXPos = 0f;
                currentRecoilYPos = 0f;
                currentRecoilZPos = 0f;
            }
        }

        if(isAutomatic)
        {
            if (Input.GetButton("Fire1"))
            {
                currentRecoilZPos -= recoilAmount_z;
                currentRecoilXPos -= (Random.value - 0.3f) * recoilAmount_x;
                currentRecoilYPos -= (Random.value - 0.9f) * recoilAmount_y;
                mouseLookScript.currentMouseDelta.y += Mathf.Abs(currentRecoilYPos * gunPrecision * Time.deltaTime);
                mouseLookScript.currentMouseDelta.x -= (currentRecoilXPos * gunPrecision * Time.deltaTime);
            }

            else
            {
                currentRecoilXPos = 0f;
                currentRecoilYPos = 0f;
                currentRecoilZPos = 0f;
            }
        }
    }
}
