using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    Vector3 position;
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car4;
    GameObject SelectedCar;
    private float Car;


    private void Start()
    {
         Car = CarSelector.Car;

         Debug.Log("Car = " + Car);

         if (Car == 1)
         {
             SelectedCar = Car1;
         }
         else if (Car == 2)
         {
             SelectedCar = Car2;
         }
         else if (Car == 3)
         {
         SelectedCar = Car3;
         }
         else if (Car == 4)
         {
             SelectedCar = Car4;

         }

         Debug.Log("SelectedCar is:" + SelectedCar);
         
        position.x = 105;
        position.y = 255;
        position.z = -39;

        SelectedCar.transform.position = position;
     
    }
    public void PGRSetCarPosition()
    {
        position.x = 105;
        position.y = 255;
        position.z = -39;
         SelectedCar.transform.position = position;
      
        

    }
}
