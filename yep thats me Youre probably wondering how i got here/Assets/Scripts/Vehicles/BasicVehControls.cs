using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityStandardAssets.Vehicles.Car;
using EZCameraShake;


public class BasicVehControls : MonoBehaviour
{
    //public static float TorqueTranslatorController = Player.TorqueTranslator;
    public int bhp;
    public float torque;
    public int brakeTorque;
    public GameObject MenuNotEnoughMoney;
    public GameObject MenuEnoughMoney;

    private float UpgradeCheckValidator = 1;

    public int turbo_upgrade;
    public int transmission_upgrade;
    public int engine_upgrade;
    public int nitrous_upgrade;
    public int tires_upgrade;
    //public static int turbo_upgrade_translator;
    public float[] gearRatio;
    public int currentGear;

    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;
    public GameObject NOS_Flames;
    public float NOSPOWER;
    public GameObject Nitrous_Button;
    int moneyToSubtractNOS = 1000;
    int moneyToSubtractTurbo = 1000;
    int moneyToSubtractTransmission = 1000;
    int moneyToSubtractTires = 1000;
    int moneyToSubtractEngine = 1000;

    public static int MoneyTranslator;
    public int maxSpeed;
    public int maxRevSpeed;

    public float SteerAngle;
    public float currentSpeed;
    public float engineRPM;
    public float gearUpRPM;
    public float gearDownRPM;
    private UnityEngine.Vector3 COM;
    public bool Upgrade = false;

    public bool handBraked;

    public List<AudioSource> CarSound;

    public float[] MinRpmTable = { 50.0f, 75.0f, 112.0f, 166.9f, 222.4f, 278.3f, 333.5f, 388.2f, 435.5f, 483.3f, 538.4f, 594.3f, 643.6f, 692.8f, 741.9f, 790.0f };
    public float[] NormalRpmTable = { 72.0f, 93.0f, 155.9f, 202.8f, 267.0f, 314.5f, 377.4f, 423.9f, 472.1f, 519.4f, 582.3f, 631.3f, 680.8f, 729.4f, 778.8f, 826.1f };
    public float[] MaxRpmTable = { 92.0f, 136.0f, 182.9f, 247.4f, 294.3f, 357.5f, 403.6f, 452.5f, 499.3f, 562.5f, 612.3f, 661.6f, 708.8f, 758.9f, 806.0f, 1000.0f };
    public float[] PitchingTable = { 0.12f, 0.12f, 0.12f, 0.12f, 0.11f, 0.10f, 0.09f, 0.08f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f };
    public float RangeDivider = 4f;
    public float soundRPM;
    public Rigidbody rb;
    float Nitrous = SimpleInput.GetAxis("Nitrous");
    void Start()
    {

        
        turbo_upgrade = Player.turbo_upgrade_translator_SelectedCar;
        nitrous_upgrade = Player.nitrous_upgrade_translator_SelectedCar;
        transmission_upgrade = Player.transmission_upgrade_translator_SelectedCar;
        engine_upgrade = Player.engine_upgrade_translator_SelectedCar;
        tires_upgrade = Player.tires_upgrade_translator_SelectedCar;

        if (turbo_upgrade > 0)
        {

            torque += 100 * turbo_upgrade;

        }
        if (nitrous_upgrade > 0)
        {

            Nitrous_Button.SetActive(true);

        }

        if (transmission_upgrade > 0)
        {

            torque += 100 * transmission_upgrade;

        }
        if (engine_upgrade > 0)
        {

            torque += 100 * engine_upgrade;

        }
        if (tires_upgrade > 0)
        {

            torque += 100 * tires_upgrade;

        }

    

        FL = GameObject.Find("WlFL.Col").GetComponent<WheelCollider>();
        FR = GameObject.Find("WlFR.Col").GetComponent<WheelCollider>();
        RL = GameObject.Find("WlRL.Col").GetComponent<WheelCollider>();
        RR = GameObject.Find("WlRR.Col").GetComponent<WheelCollider>();

       // rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = COM;

        for (int i = 1; i <= 16; ++i)
        {
            CarSound.Add(GameObject.Find(string.Format("CarSound ({0})", i)).GetComponent<AudioSource>());
            CarSound[i - 1].Play();
        }

    }
    float timeLeft = 3.0f;

    public void NOS()
    {
        NOS_Flames.SetActive(true);
        Nitrous = Nitrous + NOSPOWER;
        Invoke("EndNitrous", 4);

    }
    
    void Update()
    {
       



        //Functions to access.
        Steer();
        AutoGears();
        Accelerate();
        carSounds();
        
        

        //Defenitions.

        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.magnitude * 3.6f;
        engineRPM = Mathf.Round((RL.rpm * gearRatio[currentGear]));
        soundRPM = Mathf.Round(engineRPM * (1000 / 420));
        torque = bhp * gearRatio[currentGear];


        if (SimpleInput.GetKey(KeyCode.R))
        {

            transform.position.Set(transform.position.x, transform.position.y + 5f, transform.position.z);
            transform.rotation.Set(0, 0, 0, 0);
        }
    }

    
        //Function
        void EndNitrous()
    {
        NOS_Flames.SetActive(false);
        Nitrous = Nitrous - NOSPOWER;
        
    }

    void Accelerate()
    {
      

        if (currentSpeed < maxSpeed && currentSpeed > maxRevSpeed && engineRPM <= gearUpRPM)
        {
            
            RL.motorTorque = torque * SimpleInput.GetAxis("Vertical") + Nitrous;
            RR.motorTorque = torque * SimpleInput.GetAxis("Vertical") + Nitrous;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
        else
        {

            RL.motorTorque = 0;
            RR.motorTorque = 0;
            RL.brakeTorque = brakeTorque;
            RR.brakeTorque = brakeTorque;
        }

        if (engineRPM > 0 && SimpleInput.GetAxis("Vertical") < 0 && engineRPM <= gearUpRPM)
        {

            FL.brakeTorque = brakeTorque;
            FR.brakeTorque = brakeTorque;
            RR.brakeTorque = brakeTorque;
            RL.brakeTorque = brakeTorque;
        }
        else
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
        }
    }
    //public float SteerRate = 45;
    void Steer()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;

        if (currentSpeed < 1000)
        {
            SteerAngle = 30 - (currentSpeed / 12) + 1.5f;
        }
        var Ldestination = FL.steerAngle;
        var Rdestination = FR.steerAngle;
        
        //FL.steerAngle = SteerAngle * SimpleInput.GetAxis("Horizontal");
        //FR.steerAngle = SteerAngle * SimpleInput.GetAxis("Horizontal");

        FL.steerAngle = Mathf.MoveTowards(SteerAngle * SimpleInput.GetAxis("Horizontal"), Ldestination, Time.deltaTime);
        FR.steerAngle = Mathf.MoveTowards(SteerAngle * SimpleInput.GetAxis("Horizontal"), Rdestination, Time.deltaTime);
    }


    void AutoGears()
    {

        int AppropriateGear = currentGear;

        if (engineRPM >= gearUpRPM)
        {

            for (var i = 0; i < gearRatio.Length; i++)
            {
                if (RL.rpm * gearRatio[i] < gearUpRPM)
                {
                    AppropriateGear = i;
                    break;
                }
            }
            currentGear = AppropriateGear;
        }

        if (engineRPM <= gearDownRPM)
        {
            AppropriateGear = currentGear;
            for (var j = gearRatio.Length - 1; j >= 0; j--)
            {
                if (RL.rpm * gearRatio[j] > gearDownRPM)
                {
                    AppropriateGear = j;
                    break;
                }
            }
            currentGear = AppropriateGear;
        }
    }

    public void subtractMoneyNOS()
    {
        if (MoneyTranslator - moneyToSubtractNOS < 0)
        {
            MenuNotEnoughMoney.SetActive(true);
           
        }
        else
        {
            MenuEnoughMoney.SetActive(true);
            MoneyTranslator -= moneyToSubtractNOS;
            //   moneyText.text = money.ToString();
           
        }
    }
    public void subtractMoneyTransmission()
    {
        if (MoneyTranslator - moneyToSubtractTransmission < 0)
        {
            MenuNotEnoughMoney.SetActive(true);
            
        }
        else
        {
            MenuEnoughMoney.SetActive(true);
            MoneyTranslator -= moneyToSubtractTransmission;
            //   moneyText.text = money.ToString();
            
        }
    }

    public void subtractMoneyTurbo()
    {
        Debug.Log("Function running");
        if (MoneyTranslator - moneyToSubtractTurbo < 0)
        {
            Debug.Log("No money menu active");
            MenuNotEnoughMoney.SetActive(true);
            Debug.Log("No money menu still active");
        }
        else
        {
            Debug.Log("Enough money menu active");
            MenuEnoughMoney.SetActive(true);
            Debug.Log("EnoughMoneyMenu still active");
            MoneyTranslator -= moneyToSubtractTurbo;
            Debug.Log("MoneySubtraction");
            Debug.Log("MoneyBalanceAfterSubtracion:" + MoneyTranslator);
            //   moneyText.text = money.ToString();
            
        }
    }

    public void subtractMoneyTires()
    {
        if (MoneyTranslator - moneyToSubtractTires < 0)
        {
            MenuNotEnoughMoney.SetActive(true);

        }
        else
        {
            MenuEnoughMoney.SetActive(true);
            MoneyTranslator -= moneyToSubtractTires;
            

        }
    }

    public void subtractMoneyEngine()
    {
        if (MoneyTranslator - moneyToSubtractEngine < 0)
        {
            MenuNotEnoughMoney.SetActive(true);

        }
        else
        {
            MenuEnoughMoney.SetActive(true);
            MoneyTranslator -= moneyToSubtractEngine;
            //   moneyText.text = money.ToString();

        }
    }


    public void MoneyCheck()
    {
        Debug.Log("Money checker is active");
        MoneyTranslator = Player.MoneyTranslator;
        Debug.Log("Money checker is still active");



    }

   public void Nitrous_Purchase()
    {
        

        if(MoneyTranslator >= 1000)
        {
            Upgrade = true;
           if(Upgrade == true)
           {
                nitrous_upgrade = 1;
           Nitrous_Button.SetActive(true);
                Debug.Log("nitrous_upgrade:" + nitrous_upgrade);
           
           }
 
        }
        else
        {
            Debug.Log("No money for NOS");
            Nitrous_Button.SetActive(false);
        }

    }


    public void Turbo_Purchase()
    {
        

        if (MoneyTranslator >= 1000)
        {
            Upgrade = true;
            if (Upgrade == true)
            {
                turbo_upgrade += 1;
                torque += 100 * turbo_upgrade;
                Debug.Log("turbo_upgrade_purchase:" + turbo_upgrade);
            }

        }
        else
        {

            Debug.Log("No money for turbo");
        }

    }

    public void Transmission_Purchase()
    {
        Debug.Log("YourBalanceForPurchasingIs:" + MoneyTranslator);

        if (MoneyTranslator >= 1000)
        {
            Upgrade = true;
            if (Upgrade == true)
            {
                transmission_upgrade += 1;
                torque += 100 * transmission_upgrade;
                Debug.Log("transmission_upgrade:" + transmission_upgrade);
            }

        }
        else
        {
           
            Debug.Log("No money for transmission");
           
        }

    }

    public void Engine_Purchase()
    {
        Debug.Log("YourBalanceForPurchasingIs:" + MoneyTranslator);

        if (MoneyTranslator >= 1000)
        {
            Upgrade = true;
            if (Upgrade == true)
            {
                engine_upgrade += 1;
                torque += 100 * engine_upgrade;
                Debug.Log("engine_upgrade:" + engine_upgrade);
            }

        }
        else
        {
            
            Debug.Log("No money for engine");

        }

    }

    public void Tires_Purchase()
    {
        Debug.Log("YourBalanceForPurchasingIs:" + MoneyTranslator);

        if (MoneyTranslator >= 1000)
        {
            Upgrade = true;
            if (Upgrade == true)
            {
                tires_upgrade += 1;
                torque += 100 * tires_upgrade;

            }

        }
        else
        {
            
            Debug.Log("No money for tires");

        }

    }

   public void UpgradeChecker()
    {
        if (UpgradeCheckValidator == 1)
        {
            if (turbo_upgrade > 0)
            {

                torque += 100 * turbo_upgrade;

            }
            if (nitrous_upgrade > 0)
            {

                Nitrous_Button.SetActive(true);

            }

            if (transmission_upgrade > 0)
            {

                torque += 100 * transmission_upgrade;

            }
            if (engine_upgrade > 0)
            {

                torque += 100 * engine_upgrade;

            }
            if (tires_upgrade > 0)
            {

                torque += 100 * tires_upgrade;

            }

            UpgradeCheckValidator = 0;

            Debug.Log("UpgradeCheckValidator = " + UpgradeCheckValidator);
        }
    }

    void carSounds()
    {

        for (int i = 0; i < 16; i++)
        {
            if (i == 0)
            {
                //Set CarSound[0]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[0].volume = 0.00001f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[0].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[0].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[0].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[0].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[0].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[0].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 1)
            {
                //Set CarSound[1]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[1].volume = 1.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[1].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[1].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[1].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[1].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[1].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[1].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 2)
            {
                //Set CarSound[2]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[2].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[2].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[2].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[2].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[2].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[2].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[2].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 3)
            {
                //Set CarSound[3]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[3].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[3].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[3].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[3].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[3].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[3].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[3].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 4)
            {
                //Set CarSound[4]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[4].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[4].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[4].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[4].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[4].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[4].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[4].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 5)
            {
                //Set CarSound[5]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[5].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[5].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[5].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[5].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[5].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[5].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[5].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 6)
            {
                //Set CarSound[6]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[6].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[6].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[6].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[6].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[6].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[6].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[6].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 7)
            {
                //Set CarSound[7]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[7].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[7].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[7].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[7].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[7].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[7].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[7].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 8)
            {
                //Set CarSound[8]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[8].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[8].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[8].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[8].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[8].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[8].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[8].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 9)
            {
                //Set CarSound[9]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[9].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[9].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[9].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[9].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[9].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[9].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[9].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 10)
            {
                //Set CarSound[10]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[10].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[10].volume = ((ReducedRPM / Range) * 2f) - 1f;
                    //CarSound[10].volume = 0.0f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[10].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[10].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[10].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[10].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[10].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 11)
            {
                //Set CarSound[11]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[11].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[11].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[11].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[11].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[11].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[11].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[11].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 12)
            {
                //Set CarSound[12]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[12].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[12].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[12].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[12].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[12].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[12].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[12].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 13)
            {
                //Set CarSound[13]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[13].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[13].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[13].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[13].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[13].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[13].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[13].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 14)
            {
                //Set CarSound[14]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[14].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[14].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[14].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[14].volume = 1f;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[14].pitch = 1f + PitchMath;
                }
                else if (soundRPM > MaxRpmTable[i])
                {
                    float Range = (MaxRpmTable[i + 1] - MaxRpmTable[i]) / RangeDivider;
                    float ReducedRPM = soundRPM - MaxRpmTable[i];
                    CarSound[14].volume = 1f - ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    //CarSound[14].pitch = 1f + PitchingTable[i] + PitchMath;
                }
            }
            else if (i == 15)
            {
                //Set CarSound[15]
                if (soundRPM < MinRpmTable[i])
                {
                    CarSound[15].volume = 0.0f;
                }
                else if (soundRPM >= MinRpmTable[i] && soundRPM < NormalRpmTable[i])
                {
                    float Range = NormalRpmTable[i] - MinRpmTable[i];
                    float ReducedRPM = soundRPM - MinRpmTable[i];
                    CarSound[15].volume = ReducedRPM / Range;
                    float PitchMath = (ReducedRPM * PitchingTable[i]) / Range;
                    CarSound[15].pitch = 1f - PitchingTable[i] + PitchMath;
                }
                else if (soundRPM >= NormalRpmTable[i] && soundRPM <= MaxRpmTable[i])
                {
                    float Range = MaxRpmTable[i] - NormalRpmTable[i];
                    float ReducedRPM = soundRPM - NormalRpmTable[i];
                    CarSound[15].volume = 1f;
                    float PitchMath = (ReducedRPM * (PitchingTable[i] + 0.1f)) / Range;
                    CarSound[15].pitch = 1f + PitchMath;
                }
            }
        }
    }
   
    }



