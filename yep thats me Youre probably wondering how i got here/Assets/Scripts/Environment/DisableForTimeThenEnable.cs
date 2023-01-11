using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableForTimeThenEnable : MonoBehaviour
{
    public GameObject NOS_button;
    private Button button;
    public void Disable()
    {
       button = NOS_button.GetComponent<Button>();
        button.interactable = false;

        Invoke("Enable", 12);
    }

    private void Enable()
    {
        button.interactable = true;
    }
}
