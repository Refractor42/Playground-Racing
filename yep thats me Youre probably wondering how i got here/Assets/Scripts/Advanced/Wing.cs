using UnityEngine;
using System.Collections;

public class Wing : MonoBehaviour
{

    Rigidbody body;
    public float liftCoefficient;

    void Start()
    {

        Transform trs = transform;
        while (trs != null && trs.GetComponent<Rigidbody>() == null)
            trs = trs.parent;

        if (trs != null)
            body = trs.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float lift;
        if (gameObject.transform.rotation.x > 10)
        {
            
        }
        else
        {
            if (body != null)
            {

                lift = liftCoefficient * body.velocity.sqrMagnitude;
                body.AddForceAtPosition(lift * -transform.up, transform.position);
            }
        }
    }
}