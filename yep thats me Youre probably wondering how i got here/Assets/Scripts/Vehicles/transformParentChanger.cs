using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class transformParentChanger : MonoBehaviour
{
    public Transform TargetCops;
    public Transform Serry;
    public Transform Lemmy;
    public Transform Mercy;

   void SetParentSerry(Transform Serry)
    {
        TargetCops.transform.SetParent(Serry);
    }
    void SetParentLemmy(Transform Lemmy)
    {
        TargetCops.transform.SetParent(Lemmy);
    }
    void SetParentMercy(Transform Mercy)
    {
        TargetCops.transform.SetParent(Mercy);
    }
   
}
