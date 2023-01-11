using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour

{
   
    void Start()
    {
        Invoke("MyLoadingFunction", 2f);
    }
    void MyLoadingFunction()
    {
        SceneManager.LoadScene(1);
    }

}
