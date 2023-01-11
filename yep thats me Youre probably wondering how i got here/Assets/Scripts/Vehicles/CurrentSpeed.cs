using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using TMPro;
public class CurrentSpeed : MonoBehaviour
{
    public  TextMeshProUGUI Speedometer;

    public float currentSpeed;
    public Rigidbody rb;
    private void Update()
    {
        Speedometer = GameObject.Find("Speedometer").GetComponent<TextMeshProUGUI>();

        Speedometer.text = currentSpeed.ToString();

        



        rb = GetComponent<Rigidbody>();
        currentSpeed = Mathf.Round( rb.velocity.magnitude * 3.6f);
        CameraShake();
    }
    void CameraShake()
    {
        if (currentSpeed > 50)
        {
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .5f);
        }
    }
}
