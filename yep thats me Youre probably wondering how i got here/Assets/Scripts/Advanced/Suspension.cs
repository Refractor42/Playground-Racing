using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour
{


    private Transform wheelMesh;
    private WheelCollider wheelCollider;
    string currentWl;

    void Start()
    {

        wheelCollider = gameObject.GetComponent<WheelCollider>();

        if (this.gameObject.name == "WlFL.Col") { currentWl = "FL"; }
        else if (this.gameObject.name == "WlFR.Col") { currentWl = "FR"; }
        else if (this.gameObject.name == "WlRL.Col") { currentWl = "RL"; }
        else if (this.gameObject.name == "WlRR.Col") { currentWl = "RR"; }

        wheelMesh = GameObject.Find(currentWl).transform;
    }
    
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(wheelCollider.transform.position, -wheelCollider.transform.up,out hit, wheelCollider.suspensionDistance + wheelCollider.radius))
        {
            wheelMesh.position = hit.point + wheelCollider.transform.up * wheelCollider.radius;
        }

        else
        {
            wheelMesh.position = wheelCollider.transform.position - (wheelCollider.transform.up * wheelCollider.suspensionDistance);
        }
        
        wheelMesh.transform.Rotate(wheelCollider.rpm / 60 * 360 * Time.deltaTime * 1, 0, 0);
        Vector3 p = transform.localEulerAngles;
        p.y = wheelCollider.steerAngle - wheelMesh.localEulerAngles.z;
    }
}