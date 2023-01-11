using UnityEngine;
using System.Collections;

public class Antiroll_Bar : MonoBehaviour
{

    private Rigidbody rb;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public string wheelLname;
    public string wheelRname;

    public WheelCollider WheelL;
    public WheelCollider WheelR;
    public float AntiRoll = 5000.0f;

    void Start()
    {

        WheelL = GameObject.Find(wheelLname).GetComponent<WheelCollider>();
        WheelR = GameObject.Find(wheelRname).GetComponent<WheelCollider>();
    }


    void FixedUpdate()
    {

        WheelHit hit;
        

        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

        bool groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL) {
            rb.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
                   WheelL.transform.position);
        }


        if (groundedR)
           rb.AddForceAtPosition(WheelR.transform.up * antiRollForce,
                   WheelR.transform.position);
    }


}
