using UnityEngine;
using System.Collections;

public class CarSelector : MonoBehaviour {

    
    public GameObject Water;
    public GameObject Miscallenous;
    public GameObject Mercy;
    public GameObject The_Stuff_Mercy;
    public GameObject Serry;
    public GameObject The_Stuff_Serry;
    public GameObject Lemmy;
    public GameObject The_Stuff_Lemmy;
    public GameObject Ferry;
    public GameObject The_Stuff_Ferry;
    public GameObject Controller_Mercy;
    public GameObject Controller_Lemmy;
    public GameObject Controller_Serry;
    public GameObject Controller_Ferry;
    public GameObject TuningMenuPlaneMercy;
    public GameObject TuningMenuPlaneSerry;
    public GameObject TuningMenuPlaneLemmy;
    public GameObject TuningMenuPlaneTocus;
    public int carSelected;
    public static int Car = 1;
    public Transform TargetCops;
    public Transform SerryTarget;
    public Transform LemmyTarget;
    public Transform MercyTarget;
    
    public void loadThe_Controller()

    {
        if (Car == 1)
        {
            Controller_Mercy.SetActive(true);
            Controller_Serry.SetActive(false);
            Controller_Lemmy.SetActive(false);
            Controller_Ferry.SetActive(false);
        }
        else if (Car == 2)
        {
            Controller_Serry.SetActive(true);
            Controller_Mercy.SetActive(false);
            Controller_Lemmy.SetActive(false);
            Controller_Ferry.SetActive(false);
        }
        else if (Car == 3)
        {
            Controller_Lemmy.SetActive(true);
            Controller_Mercy.SetActive(false);
            Controller_Serry.SetActive(false);
            Controller_Ferry.SetActive(false);
        }
        else if (Car == 4)
        {
            Controller_Ferry.SetActive(true);
            Controller_Mercy.SetActive(false);
            Controller_Serry.SetActive(false);
            Controller_Lemmy.SetActive(false);

        }
    }
    public void loadThe_Stuff()
    {
        if (Car == 1)
        {
            TargetCops.transform.SetParent(MercyTarget);
            The_Stuff_Mercy.SetActive(true);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 2)
        {
            TargetCops.transform.SetParent(SerryTarget);
            The_Stuff_Serry.SetActive(true);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 3)
        {
            TargetCops.transform.SetParent(LemmyTarget);
            The_Stuff_Lemmy.SetActive(true);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 4)
        {
            
            The_Stuff_Ferry.SetActive(true);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);

        }
    }
    public void unloadThe_Stuff()
    {
        if (Car == 1)
        {
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 2)
        {
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 3)
        {
            The_Stuff_Lemmy.SetActive(false);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Ferry.SetActive(false);
        }
        else if (Car == 4)
        {
            The_Stuff_Ferry.SetActive(false);
            The_Stuff_Mercy.SetActive(false);
            The_Stuff_Serry.SetActive(false);
            The_Stuff_Lemmy.SetActive(false);

        }
    }
    public void unloadCars()
    {

        Mercy.SetActive(false);
        Serry.SetActive(false);
        Lemmy.SetActive(false);
        Ferry.SetActive(false);

    }

 

    //void Awake()
    // {

    //   if (instance != null && instance != this)
    //  {
    //    Destroy(this.gameObject);
    //  return;
    // }
    // else
    //{
    // just move it to the root
    //  this.transform.parent = null;

    //instance = this;

    //}
    // DontDestroyOnLoad(this.gameObject);
    // }
    // void Awake()
    // {


    //    if (instance == null)
    //   {
    //       DontDestroyOnLoad(this);
    //        instance = this;
    //   }
    // else
    //   {
    //      Object.Destroy(this);
    //  }
    //  }

    public void unclicked()
    {

        if (Car < 5 && Car > 1)
        {
            Car = Car - 1;
        };
        carSelected = Car;
        if (Car == 1)
        {
            TuningMenuPlaneMercy.SetActive(true);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(false);
            Mercy.SetActive(true);
            Serry.SetActive(false);
            Lemmy.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 2)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(true);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(false);
            Serry.SetActive(true);
            Mercy.SetActive(false);
            Lemmy.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 3)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(true);
            TuningMenuPlaneTocus.SetActive(false);
            Lemmy.SetActive(true);
            Mercy.SetActive(false);
            Serry.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 4)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(true);
            Ferry.SetActive(true);
            Mercy.SetActive(false);
            Serry.SetActive(false);
            Lemmy.SetActive(false);

        }
    }
    public void clicked()
    {
        if (Car < 4 && Car > 0)
        {
            Car = Car + 1;
        };
        carSelected = Car;
        if (Car == 1)
        {
            TuningMenuPlaneMercy.SetActive(true);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(false);
            Mercy.SetActive(true);
            Serry.SetActive(false);
            Lemmy.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 2)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(true);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(false);
            Serry.SetActive(true);
            Mercy.SetActive(false);
            Lemmy.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 3)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(true);
            TuningMenuPlaneTocus.SetActive(false);
            Lemmy.SetActive(true);
            Mercy.SetActive(false);
            Serry.SetActive(false);
            Ferry.SetActive(false);
        }
        else if (Car == 4)
        {
            TuningMenuPlaneMercy.SetActive(false);
            TuningMenuPlaneSerry.SetActive(false);
            TuningMenuPlaneLemmy.SetActive(false);
            TuningMenuPlaneTocus.SetActive(true);
            Ferry.SetActive(true);
            Mercy.SetActive(false);
            Serry.SetActive(false);
            Lemmy.SetActive(false);

        }
    }
    //public void Destroy()
    //{

      //  Object.Destroy(Mercy);
        //Object.Destroy(Serry);
        //Object.Destroy(Lemmy);
        //Object.Destroy(The_Stuff_Mercy);
        //Object.Destroy(The_Stuff_Serry);
        //Object.Destroy(The_Stuff_Lemmy);
        //Object.Destroy(Miscallenous);
                           
    //}
    private static GameObject instance;
    void Start()
    {



        TuningMenuPlaneMercy.SetActive(true);
        TuningMenuPlaneSerry.SetActive(false);
        TuningMenuPlaneLemmy.SetActive(false);
        TuningMenuPlaneTocus.SetActive(false);
        Mercy.SetActive(true);
        Serry.SetActive(false);
        Lemmy.SetActive(false);
        Ferry.SetActive(false);
        carSelected = 1;

    }
    
    public void loadMercy () {

        TuningMenuPlaneMercy.SetActive(true);
        TuningMenuPlaneSerry.SetActive(false);
        TuningMenuPlaneLemmy.SetActive(false);
        TuningMenuPlaneTocus.SetActive(false);
        Mercy.SetActive(true); 
        Serry.SetActive (false);
        Lemmy.SetActive (false);
        Ferry.SetActive(false);
        carSelected = 1;
    }

    public void loadSerry () {
        TuningMenuPlaneMercy.SetActive(false);
        TuningMenuPlaneSerry.SetActive(true);
        TuningMenuPlaneLemmy.SetActive(false);
        TuningMenuPlaneTocus.SetActive(false);
        Mercy.SetActive (false);
        Serry.SetActive (true);
        Lemmy.SetActive (false);
        Ferry.SetActive(false);

        carSelected = 2;
    }

    public void loadLemmy () {
        TuningMenuPlaneMercy.SetActive(false);
        TuningMenuPlaneSerry.SetActive(false);
        TuningMenuPlaneLemmy.SetActive(true);
        TuningMenuPlaneTocus.SetActive(false);
        Mercy.SetActive (false);
        Serry.SetActive (false);
        Lemmy.SetActive (true);
        Ferry.SetActive(false);

        carSelected = 3;
    }
    public void loadFerry()
    {
        TuningMenuPlaneMercy.SetActive(false);
        TuningMenuPlaneSerry.SetActive(false);
        TuningMenuPlaneLemmy.SetActive(false);
        TuningMenuPlaneTocus.SetActive(true);
        Mercy.SetActive(false);
        Serry.SetActive(false);
        Lemmy.SetActive(false);
        Ferry.SetActive(true);
        carSelected = 4;
    }
    public void DontDestroyOnLoad()
    {
        
        if(carSelected == 1)
        {
            
            Water.transform.parent = null;
            Controller_Mercy.transform.parent = null;
            Miscallenous.transform.parent = null;
           Mercy.transform.parent = null;
            The_Stuff_Mercy.transform.parent = null;
            DontDestroyOnLoad(Mercy);
            DontDestroyOnLoad(The_Stuff_Mercy);
            DontDestroyOnLoad(Miscallenous);
            DontDestroyOnLoad(Controller_Mercy);
            DontDestroyOnLoad(Water);
            
        }
        if (carSelected == 2)
        {
            Miscallenous.transform.parent = null;
            Serry.transform.parent = null;
            The_Stuff_Serry.transform.parent = null;
            DontDestroyOnLoad(Serry);
            DontDestroyOnLoad(The_Stuff_Serry);
            DontDestroyOnLoad(Miscallenous);
        }
        if (carSelected == 3)
        {
            Miscallenous.transform.parent = null;
            Lemmy.transform.parent = null;
            The_Stuff_Lemmy.transform.parent = null;
            DontDestroyOnLoad(Lemmy);
            DontDestroyOnLoad(The_Stuff_Lemmy);
            DontDestroyOnLoad(Miscallenous);
        }
    }
}
