using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UltimateCarController : MonoBehaviour
{

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public Transform wheelFL_Trans;
    public Transform wheelFR_Trans;
    public Transform wheelRL_Trans;
    public Transform wheelRR_Trans;

    public float lowSpeedSteerAngle;
    public float highSpeedSteerAngle;
    public float Torque;
    public float centerOfMassHeight;

    public float speed;
    public GameObject speedometer;
    public GameObject accelerator;
    public GameObject brake;
    public float pedalRotationFactor;
    public float speedometerRotationFactor;
    public float decelerationRate;

    public float currentSpeed;
    public float topSpeed;
    public float maxReverseSpeed;

    public GameObject trunk;
    public Material[] brakeMaterials;

    public float currentSteerAngle;
    public float turnAmount;

    private Vector3 com;
    private Rigidbody rigidBody;
    private float acceleratorSpeed;
    private float brakeSpeed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        com = rigidBody.centerOfMass;
        com.y = centerOfMassHeight;
        rigidBody.centerOfMass = com;
    }

    void FixedUpdate()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if (currentSpeed < topSpeed && currentSpeed > -maxReverseSpeed)
        {
            wheelFL.motorTorque = Torque * Input.GetAxis("Vertical");
            wheelFR.motorTorque = Torque * Input.GetAxis("Vertical");
            wheelRL.motorTorque = Torque * Input.GetAxis("Vertical");
            wheelRR.motorTorque = Torque * Input.GetAxis("Vertical");
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
        }


        if (!Input.GetButton("Vertical"))
        {
            wheelFL.brakeTorque = decelerationRate;
            wheelFR.brakeTorque = decelerationRate;
            wheelRL.brakeTorque = decelerationRate;
            wheelRR.brakeTorque = decelerationRate;
        }
        else
        {
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            //Changing The Materials
            Material[] mats = trunk.GetComponent<Renderer>().materials;
            mats[0] = brakeMaterials[1];

            trunk.GetComponent<Renderer>().materials = mats;
        }
        else
        {
            //Reseting The Materials
            Material[] mats = trunk.GetComponent<Renderer>().materials;
            mats[0] = brakeMaterials[0];

            trunk.GetComponent<Renderer>().materials = mats;
        }

        speed = GetComponent<Rigidbody>().velocity.magnitude * 15;
        float speedFactor = 1 - (GetComponent<Rigidbody>().velocity.magnitude * 3.6f / topSpeed);
        currentSteerAngle = highSpeedSteerAngle + ((lowSpeedSteerAngle - highSpeedSteerAngle) * speedFactor);
        turnAmount = currentSteerAngle * Input.GetAxis("Horizontal");
        wheelFL.steerAngle = turnAmount;
        wheelFR.steerAngle = turnAmount;
    }

    void Update()
    {
        wheelFL_Trans.Rotate(0, 0, wheelFL.rpm / 60 * 360 * Time.deltaTime);
        wheelFR_Trans.Rotate(0, 0, wheelFR.rpm / 60 * 360 * Time.deltaTime);
        wheelRL_Trans.Rotate(0, 0, wheelRL.rpm / 60 * 360 * Time.deltaTime);
        wheelRR_Trans.Rotate(0, 0, wheelRR.rpm / 60 * 360 * Time.deltaTime);

        Vector3 wheelSteerAngle = wheelFL_Trans.localEulerAngles;
        wheelSteerAngle.y = turnAmount + 90;
        wheelFL_Trans.localEulerAngles = wheelSteerAngle;
        wheelFR_Trans.localEulerAngles = wheelSteerAngle;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 resetPosition = new Vector3(transform.position.x, 1.5f, transform.position.z);
            Quaternion resetRotation = Quaternion.Euler(0f, 0f, 0f);

            //Reseting Velocity
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

            //Reseting Rotation
            transform.rotation = resetRotation;

            //Reseting Position
            transform.position = resetPosition;

            //Reseting Motor Torque and Steering Angle
            wheelFL.motorTorque = 0f;
            wheelFR.motorTorque = 0f;
            wheelRL.motorTorque = 0f;
            wheelRR.motorTorque = 0f;

            wheelFL.steerAngle = 0f;
            wheelFR.steerAngle = 0f;
            wheelRL.steerAngle = 0f;
            wheelRR.steerAngle = 0f;
        }

        acceleratorSpeed = wheelFL.motorTorque;
        brakeSpeed = wheelFL.motorTorque;

        if (acceleratorSpeed < 0)
        {
            acceleratorSpeed = 0;
        }

        if (brakeSpeed > 0)
        {
            brakeSpeed = 0;
        }

        if (speed >= 350)
        {
            speed = 350;
        }

        speedometer.transform.localRotation = Quaternion.Euler(speed * speedometerRotationFactor - 100, 90f, 0f);
        accelerator.transform.localRotation = Quaternion.Euler(acceleratorSpeed * pedalRotationFactor, 0f, 0f);
        brake.transform.localRotation = Quaternion.Euler(brakeSpeed * pedalRotationFactor * -1, 0f, 0f);

    }
}