using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour

{
    public GameObject Miscallenous;
    public GameObject Mercy;
    public GameObject Serry;
    public GameObject Lemmy;
    public GameObject The_Stuff_Mercy;
    public GameObject The_Stuff_Serry;
    public GameObject The_Stuff_Lemmy;
    public GameObject Timer;
    public void PlayGame(int LevelLoader)
    {
        SceneManager.GetSceneByBuildIndex(LevelLoader);
        SceneManager.LoadScene(LevelLoader);


        
      
       
    }

    public void DestroyObjects ()
    {

        Object.Destroy(Mercy);
        Object.Destroy(Serry);
        Object.Destroy(Lemmy);
        Object.Destroy(The_Stuff_Mercy);
        Object.Destroy(The_Stuff_Serry);
        Object.Destroy(The_Stuff_Lemmy);
        Object.Destroy(Miscallenous);
        Object.Destroy(Timer);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
