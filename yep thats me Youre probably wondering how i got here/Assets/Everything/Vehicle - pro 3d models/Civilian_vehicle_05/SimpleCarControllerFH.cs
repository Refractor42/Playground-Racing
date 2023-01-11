using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleCarControllerFH : MonoBehaviour
{
  
    public void GetInput()
    {
        m_horizontalInput = SimpleInput.GetAxis("Horizontal");
        m_verticalInput = SimpleInput.GetAxis("Vertical");
    }
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }
    private void Accelerate()
    {
        frontDriverW.motorTorque = m_verticalInput * motorForce;
        frontPassengerW.motorTorque = m_verticalInput * motorForce;
        rearDriverW.motorTorque = m_verticalInput * motorForce;
        rearPassengerW.motorTorque = m_verticalInput * motorForce;
    }
    private void UpdateWheelPoses()
    {
        UpdateWheelPoses(frontDriverW, frontDriverT);
        UpdateWheelPoses(frontPassengerW, frontPassengerT);
        UpdateWheelPoses(rearDriverW, rearDriverT);
        UpdateWheelPoses(rearPassengerW, rearPassengerT);
    }
    private void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }
    private void Update()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle;
    
    public float motorForce = 700;

    public float currentSpeed;
    void FixedUpdate()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        if (currentSpeed > 250)
        {
            maxSteerAngle = 3;
        }
        if (currentSpeed <=250 && currentSpeed > 180)
        {
            maxSteerAngle = 5;
        }

        if (currentSpeed <= 180 && currentSpeed > 90)
        {
            maxSteerAngle = 10;
        }
        if (currentSpeed <= 90 && currentSpeed > 40)
        {
            maxSteerAngle = 20;
        }
        if (currentSpeed <= 35)
        {
            maxSteerAngle = 30;
        }
    }
    }
