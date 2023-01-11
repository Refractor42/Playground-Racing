using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int money;
    public int turbo_upgrade_Mercy;
    public int transmission_upgrade_Mercy;
    public int engine_upgrade_Mercy;
    public int nitrous_upgrade_Mercy;
    public int tires_upgrade_Mercy;

    public int turbo_upgrade_Serry;
    public int transmission_upgrade_Serry;
    public int engine_upgrade_Serry;
    public int nitrous_upgrade_Serry;
    public int tires_upgrade_Serry;

    public int turbo_upgrade_Lemmy;
    public int transmission_upgrade_Lemmy;
    public int engine_upgrade_Lemmy;
    public int nitrous_upgrade_Lemmy;
    public int tires_upgrade_Lemmy;


    public int turbo_upgrade_Tocus;
    public int transmission_upgrade_Tocus;
    public int engine_upgrade_Tocus;
    public int nitrous_upgrade_Tocus;
    public int tires_upgrade_Tocus;


    public PlayerData (Player player)
    {
        turbo_upgrade_Mercy = player.turbo_upgrade_Mercy;
        transmission_upgrade_Mercy = player.transmission_upgrade_Mercy;
        engine_upgrade_Mercy = player.engine_upgrade_Mercy;
        nitrous_upgrade_Mercy = player.nitrous_upgrade_Mercy;
        tires_upgrade_Mercy = player.tires_upgrade_Mercy;

        turbo_upgrade_Serry = player.turbo_upgrade_Serry;
        transmission_upgrade_Serry = player.transmission_upgrade_Serry;
        engine_upgrade_Serry = player.engine_upgrade_Serry;
        nitrous_upgrade_Serry = player.nitrous_upgrade_Serry;
        tires_upgrade_Serry = player.tires_upgrade_Serry;

        turbo_upgrade_Lemmy = player.turbo_upgrade_Lemmy;
        transmission_upgrade_Lemmy = player.transmission_upgrade_Lemmy;
        engine_upgrade_Lemmy = player.engine_upgrade_Lemmy;
        nitrous_upgrade_Lemmy = player.nitrous_upgrade_Lemmy;
        tires_upgrade_Lemmy = player.tires_upgrade_Lemmy;

        turbo_upgrade_Tocus = player.turbo_upgrade_Tocus;
        transmission_upgrade_Tocus = player.transmission_upgrade_Tocus;
        engine_upgrade_Tocus = player.engine_upgrade_Tocus;
        nitrous_upgrade_Tocus = player.nitrous_upgrade_Tocus;
        tires_upgrade_Tocus = player.tires_upgrade_Tocus;

        money = player.money;
   
    }
}
