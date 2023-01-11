using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void DontDestroyOnL()
    {

        DontDestroyOnLoad(this);

    }
    public void Destroy()
    {

        Object.Destroy(this);

    }
}
