using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    private int turretLvL = 1;
    private int maxTurrets = 2;
    private int maxTurretLvl = 4;
    public GameObject turret_lvl_1;
    public GameObject turret_lvl_2;
    public GameObject turret_lvl_3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMaxTurrets()
    {
        return maxTurrets;
    }

    public int GetMaxTurretLvl()
    {
        return maxTurretLvl;
    }

    public void TurretIncreaseLvl()
    {
        turretLvL = Math.Min(turretLvL + 1, maxTurretLvl);
    }
    public int GetCurrentTurretLvl()
    {
        return turretLvL;
    }
    public GameObject GetTurret()
    {
        switch (turretLvL)
        {
            case 1:
                return turret_lvl_1;
            case 2:
                return turret_lvl_2;
            case 3:
                return turret_lvl_3;
            default:
                return turret_lvl_1;
        }
    }
}
