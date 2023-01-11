using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PlayerMoney : MonoBehaviour
{
    int moneyToSubtractTurbo = 1200;
    int moneyToSubtractNOS = 1500;
    int moneyToSubtractEngine = 5000;
    int moneyToSubtractTransmission = 1000;
    int moneyToSubtractTires = 4000;
    
    public static int money;
    //public TextMeshPro moneyText;
    // Use this for initialization
    void Start()
    {
        
      //  moneyText.text = money.ToString();
    }
    // Update 15 called once per frame

    void Update()
    {

        
       
    }
    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
       // moneyText.text = money.ToString();
    }

    public void MoneyChecker()
    {
        Debug.Log("MoneyChecker is active");
        money = BasicVehControls.MoneyTranslator;
        Debug.Log("MoneyChecker is still active");


    }
    /*public void subtractMoneyTransmission()
    {
        if (money - moneyToSubtractTransmission < 0)
        {
            Debug.Log("We Dont have enough money");
            Debug.Log(money);
                }
        else
        {
            money -= moneyToSubtractTransmission;
            //   moneyText.text = money.ToString();
            Debug.Log(money);
        }
    }
    */
}
