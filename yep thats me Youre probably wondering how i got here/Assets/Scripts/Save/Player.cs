using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static int MoneyTranslator = PlayerMoney.money;
    public static int turbo_upgrade_translator_Mercy;
    public static int nitrous_upgrade_translator_Mercy;
    public static int transmission_upgrade_translator_Mercy;
    public static int engine_upgrade_translator_Mercy;
    public static int tires_upgrade_translator_Mercy;

    public static int turbo_upgrade_translator_Serry;
    public static int nitrous_upgrade_translator_Serry;
    public static int transmission_upgrade_translator_Serry;
    public static int engine_upgrade_translator_Serry;
    public static int tires_upgrade_translator_Serry;

    public static int turbo_upgrade_translator_Lemmy;
    public static int nitrous_upgrade_translator_Lemmy;
    public static int transmission_upgrade_translator_Lemmy;
    public static int engine_upgrade_translator_Lemmy;
    public static int tires_upgrade_translator_Lemmy;

    public static int turbo_upgrade_translator_Tocus;
    public static int nitrous_upgrade_translator_Tocus;
    public static int transmission_upgrade_translator_Tocus;
    public static int engine_upgrade_translator_Tocus;
    public static int tires_upgrade_translator_Tocus;
    public TextMeshPro moneyText;


    public GameObject MercyActual;
    public BasicVehControls Mercy_BasicVehControls;

    public GameObject SerryActual;
    public BasicVehControls Serry_BasicVehControls;

    public GameObject LemmyActual;
    public BasicVehControls Lemmy_BasicVehControls;

    public GameObject TocusActual;
    public BasicVehControls Tocus_BasicVehControls;


    private bool i = true;

    public int turbo_upgrade_Mercy;
    public int transmission_upgrade_Mercy;
    public int engine_upgrade_Mercy;
    public int nitrous_upgrade_Mercy;
    public int tires_upgrade_Mercy;


    public int turbo_upgrade_Serry;
    public int transmission_upgrade_Serry;
    public int engine_upgrade_Serry;
    public int nitrous_upgrade_Serry;
    public int tires_upgrade_Serry;


    public int turbo_upgrade_Lemmy;
    public int transmission_upgrade_Lemmy;
    public int engine_upgrade_Lemmy;
    public int nitrous_upgrade_Lemmy;
    public int tires_upgrade_Lemmy;


    public int turbo_upgrade_Tocus;
    public int transmission_upgrade_Tocus;
    public int engine_upgrade_Tocus;
    public int nitrous_upgrade_Tocus;
    public int tires_upgrade_Tocus;

    public int money;

    public static int SelectedCarIndex;
    public static int turbo_upgrade_translator_SelectedCar;
    public static int transmission_upgrade_translator_SelectedCar;
    public static int engine_upgrade_translator_SelectedCar;
    public static int nitrous_upgrade_translator_SelectedCar;
    public static int tires_upgrade_translator_SelectedCar;

    void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }

    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        
        money = data.money;
        MoneyTranslator = money;

        //////////////////////////////////////////////////
        turbo_upgrade_Mercy = data.turbo_upgrade_Mercy;
        turbo_upgrade_translator_Mercy = turbo_upgrade_Mercy;
        
        transmission_upgrade_Mercy = data.transmission_upgrade_Mercy;
        transmission_upgrade_translator_Mercy = transmission_upgrade_Mercy;

        engine_upgrade_Mercy = data.engine_upgrade_Mercy;
        engine_upgrade_translator_Mercy = engine_upgrade_Mercy;

        nitrous_upgrade_Mercy = data.nitrous_upgrade_Mercy;
        nitrous_upgrade_translator_Mercy = nitrous_upgrade_Mercy;

        tires_upgrade_Mercy = data.tires_upgrade_Mercy;
        tires_upgrade_translator_Mercy = tires_upgrade_Mercy;

        //////////////////////////////////////////////////
        turbo_upgrade_Serry = data.turbo_upgrade_Serry;
        turbo_upgrade_translator_Serry = data.turbo_upgrade_Serry;

        transmission_upgrade_Serry = data.transmission_upgrade_Serry;
        transmission_upgrade_translator_Serry = data.transmission_upgrade_Serry;

        engine_upgrade_Serry = data.engine_upgrade_Serry;
        engine_upgrade_translator_Serry = data.engine_upgrade_Serry;

        nitrous_upgrade_Serry = data.nitrous_upgrade_Serry;
        nitrous_upgrade_translator_Serry = data.nitrous_upgrade_Serry;

        tires_upgrade_Serry = data.tires_upgrade_Serry;
        tires_upgrade_translator_Serry = data.tires_upgrade_Serry;

        /////////////////////////////////////////////////
        turbo_upgrade_Lemmy = data.turbo_upgrade_Lemmy;
        turbo_upgrade_translator_Lemmy = data.turbo_upgrade_Lemmy;

        transmission_upgrade_Lemmy = data.transmission_upgrade_Lemmy;
        transmission_upgrade_translator_Lemmy = data.transmission_upgrade_Lemmy;

        engine_upgrade_Lemmy = data.engine_upgrade_Lemmy;
        engine_upgrade_translator_Lemmy = data.engine_upgrade_Lemmy;

        nitrous_upgrade_Lemmy = data.nitrous_upgrade_Lemmy;
        nitrous_upgrade_translator_Lemmy = data.nitrous_upgrade_Lemmy;

        tires_upgrade_Lemmy = data.tires_upgrade_Lemmy;
        tires_upgrade_translator_Lemmy = data.tires_upgrade_Lemmy;

        /////////////////////////////////////////////////
        turbo_upgrade_Tocus = data.turbo_upgrade_Tocus;
        turbo_upgrade_translator_Tocus = data.turbo_upgrade_Tocus;

        transmission_upgrade_Tocus = data.transmission_upgrade_Tocus;
        transmission_upgrade_translator_Tocus = data.transmission_upgrade_Tocus;

        engine_upgrade_Tocus = data.engine_upgrade_Tocus;
        engine_upgrade_translator_Tocus = data.engine_upgrade_Tocus;

        nitrous_upgrade_Tocus = data.nitrous_upgrade_Tocus;
        nitrous_upgrade_translator_Tocus = data.nitrous_upgrade_Tocus;

        tires_upgrade_Tocus = data.tires_upgrade_Tocus;
        tires_upgrade_translator_Tocus = data.tires_upgrade_Tocus;

        
        
        SelectedCarIndex = CarSelector.Car;
  

        if (SelectedCarIndex == 1)
        {
            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Mercy;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Mercy;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Mercy;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Mercy;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Mercy;
        }
        else if (SelectedCarIndex == 2)
        {
            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Serry;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Serry;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Serry;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Serry;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Serry;



        }
        else if (SelectedCarIndex == 3)
        {

            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Lemmy;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Lemmy;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Lemmy;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Lemmy;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Lemmy;

        }
        else if (SelectedCarIndex == 4)
        {

            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Tocus;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Tocus;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Tocus;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Tocus;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Tocus;

        }

        
        Mercy_BasicVehControls = MercyActual.GetComponent<BasicVehControls>();
        Serry_BasicVehControls = SerryActual.GetComponent<BasicVehControls>();
        Lemmy_BasicVehControls = LemmyActual.GetComponent<BasicVehControls>();
       // Tocus_BasicVehControls = TocusActual.GetComponent<BasicVehControls>();

       

  

    }

    public void AddMoney()
    {
        money += 10000;


    }
    public void SelectedCarChecker()
    {
        SelectedCarIndex = CarSelector.Car;


        if (SelectedCarIndex == 1)
        {
            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Mercy;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Mercy;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Mercy;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Mercy;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Mercy;
        }
        else if(SelectedCarIndex == 2)
        {
            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Serry;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Serry;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Serry;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Serry;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Serry;



        }
        else if(SelectedCarIndex == 3)
        {

            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Lemmy;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Lemmy;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Lemmy;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Lemmy;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Lemmy;

        }
        else if(SelectedCarIndex == 4)
        {

            turbo_upgrade_translator_SelectedCar = turbo_upgrade_translator_Tocus;
            transmission_upgrade_translator_SelectedCar = transmission_upgrade_translator_Tocus;
            engine_upgrade_translator_SelectedCar = engine_upgrade_translator_Tocus;
            nitrous_upgrade_translator_SelectedCar = nitrous_upgrade_translator_Tocus;
            tires_upgrade_translator_SelectedCar = tires_upgrade_translator_Tocus;

        }

    }


    public void MoneyCheckerPlayer ()
    {
        money = BasicVehControls.MoneyTranslator;

        turbo_upgrade_Mercy = Mercy_BasicVehControls.turbo_upgrade;
        transmission_upgrade_Mercy = Mercy_BasicVehControls.transmission_upgrade;
        engine_upgrade_Mercy = Mercy_BasicVehControls.engine_upgrade;
        nitrous_upgrade_Mercy = Mercy_BasicVehControls.nitrous_upgrade;
        tires_upgrade_Mercy = Mercy_BasicVehControls.tires_upgrade;


        turbo_upgrade_Serry = Serry_BasicVehControls.turbo_upgrade;
        transmission_upgrade_Serry = Serry_BasicVehControls.transmission_upgrade;
        engine_upgrade_Serry = Serry_BasicVehControls.engine_upgrade;
        nitrous_upgrade_Serry = Serry_BasicVehControls.nitrous_upgrade;
        tires_upgrade_Serry = Serry_BasicVehControls.tires_upgrade;


        turbo_upgrade_Lemmy = Lemmy_BasicVehControls.turbo_upgrade;
        transmission_upgrade_Lemmy = Lemmy_BasicVehControls.transmission_upgrade;
        engine_upgrade_Lemmy = Lemmy_BasicVehControls.engine_upgrade;
        nitrous_upgrade_Lemmy = Lemmy_BasicVehControls.nitrous_upgrade;
        tires_upgrade_Lemmy = Lemmy_BasicVehControls.tires_upgrade;


        // turbo_upgrade_Tocus = Tocus_BasicVehControls.turbo_upgrade;
        //transmission_upgrade_Tocus = Tocus_BasicVehControls.transmission_upgrade;
        //engine_upgrade_Tocus = Tocus_BasicVehControls.engine_upgrade;
        //nitrous_upgrade_Tocus = Tocus_BasicVehControls.nitrous_upgrade;
        //tires_upgrade_Tocus = Tocus_BasicVehControls.tires_upgrade;

     
    }
    private void Update()
    {
        moneyText.text = money.ToString();


        

    }
    public void SavePlayer()
    {
                SaveSystem.SavePlayer(this);
        
        
        
    }

    public void LoadPlayer()
    {

          
        
        
        PlayerData data = SaveSystem.LoadPlayer();
        

        money = data.money;
        MoneyTranslator = money;
       Debug.Log(MoneyTranslator);

        turbo_upgrade_Mercy = data.turbo_upgrade_Mercy;
        transmission_upgrade_Mercy = data.transmission_upgrade_Mercy;
        engine_upgrade_Mercy = data.engine_upgrade_Mercy;
        nitrous_upgrade_Mercy = data.nitrous_upgrade_Mercy;
        tires_upgrade_Mercy = data.tires_upgrade_Mercy;

        turbo_upgrade_Serry = data.turbo_upgrade_Serry;
        transmission_upgrade_Serry = data.transmission_upgrade_Serry;
        engine_upgrade_Serry = data.engine_upgrade_Serry;
        nitrous_upgrade_Serry = data.nitrous_upgrade_Serry;
        tires_upgrade_Serry = data.tires_upgrade_Serry;

        turbo_upgrade_Lemmy = data.turbo_upgrade_Lemmy;
        transmission_upgrade_Lemmy = data.transmission_upgrade_Lemmy;
        engine_upgrade_Lemmy = data.engine_upgrade_Lemmy;
        nitrous_upgrade_Lemmy = data.nitrous_upgrade_Lemmy;
        tires_upgrade_Lemmy = data.tires_upgrade_Lemmy;

        turbo_upgrade_Tocus = data.turbo_upgrade_Tocus;
        transmission_upgrade_Tocus = data.transmission_upgrade_Tocus;
        engine_upgrade_Tocus = data.engine_upgrade_Tocus;
        nitrous_upgrade_Tocus = data.nitrous_upgrade_Tocus;
        tires_upgrade_Tocus = data.tires_upgrade_Tocus;




    }
}
