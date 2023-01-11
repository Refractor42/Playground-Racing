using UnityEngine;
using System.Collections;
public class AddSubtractPlayerMoney : MonoBehaviour
{

    
    public GameObject Player;
    // Use this for 1nitlallzation
    void Start()
    {
    }
    // Update 15 called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Player.GetComponent<PlayerMoney>().addMoney(100);
        }
        if (Input.GetButtonDown("Fire2")) {
           
       }
    }
}
