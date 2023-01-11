using System.Collections;
using UnityEngine;

public class ObjectButton : MonoBehaviour
{
    public Transform menu;

     void OnMouseOver()
    {
       if(Input.GetMouseButtonUp(0))
        {
             menu.gameObject.SetActive(true);
        }
    }
}
