using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSetInactive : MonoBehaviour
{

    public GameObject Menu;
    public void DelayedSetActiveFalse()
    {

        Invoke("SetInactive", 1f);

    }

    private void SetInactive()
    {

        Menu.SetActive(false);

    }
}
