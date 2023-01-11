using UnityEngine;
using System.Collections;

public class CarLights : MonoBehaviour
{

    public Renderer brakelights;
    public Material brakelightON;
    public Material brakelightOFF;

    public Renderer headlights;
    public Material headlightsON;
    public Material headlightsOFF;

    public Renderer turnSignalLEFT;
    public Renderer turnSignalRIGHT;
    public Material turnsignalON;
    public Material turnsignalOFF;

    public Light spotlightLEFT;
    public Light spotlightRIGHT;

    private bool rightSignalON = false;
    private bool leftSignalON = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //braking//
        if (SimpleInput.GetAxis("Vertical") < 0)
        {
            brakelights.material = brakelightON;
        }
        //not braking//
        else
        {
            brakelights.material = brakelightOFF;
        }

        //headlights on/off//
        if (SimpleInput.GetAxis("Fire1") < 0)
        {
            headlights.material = headlightsON;
            spotlightLEFT.intensity = 1.5f;
            spotlightRIGHT.intensity = 1.5f;
        }
        if (SimpleInput.GetAxis("Fire1") > 0)
        {
            headlights.material = headlightsOFF;
            spotlightLEFT.intensity = 0f;
            spotlightRIGHT.intensity = 0f;
        }

        //steer right//
        if (SimpleInput.GetKey(KeyCode.RightArrow))
        {
            turnSignalRIGHT.material = turnsignalON;
            turnSignalLEFT.material = turnsignalOFF;
            rightSignalON = true;
            leftSignalON = false;
        }
        else if (SimpleInput.GetKey(KeyCode.LeftArrow))
        {
            turnSignalRIGHT.material = turnsignalOFF;
            turnSignalLEFT.material = turnsignalON;
            rightSignalON = false;
            leftSignalON = true;
        }
        else
        {
            turnSignalRIGHT.material = turnsignalOFF;
            turnSignalLEFT.material = turnsignalOFF;
            rightSignalON = false;
            leftSignalON = false;
        }

        if (leftSignalON)
        {
            float floor = 0f;
            float ceiling = 1f;
            float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
            turnSignalLEFT.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
        }
        if (rightSignalON)
        {
            float floor = 0f;
            float ceiling = 1f;
            float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);
            turnSignalRIGHT.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
        }


    }
}