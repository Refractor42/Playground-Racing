using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.acceleration.x, 1, -Input.acceleration.z);
    }
}

