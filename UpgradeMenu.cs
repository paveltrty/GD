using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class UpgradeMenu : MonoBehaviour {
    private PlayerStats ps;

    public GameObject Turrets_upgrade;
    public Button Health_upgrade; 
    // Start is called before the first frame update
    void Start()
    {
        Turrets_upgrade = transform.GetChild(1).gameObject;
        ps = GetComponentInParent<Camera>().GetComponentInParent<PlayerStats>();
        this.GameObject().SetActive(false);
    }
    
    public void Upgrade_turrets()
    {
        ps.TurretIncreaseLvl();
        if (ps.GetCurrentTurretLvl() == 3)
        {
            Turrets_upgrade.SetActive(false);
        }
    }

    public void Exit()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.GameObject().SetActive(false);
    }

    
}
