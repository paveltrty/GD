using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurretControls : MonoBehaviour {
    public PlayerStats Stats;
    
    private Queue<GameObject> turrets_q = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Stats = transform.GetComponent<PlayerStats>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z) + (transform.forward * 3);

            GameObject turret = Stats.GetTurret();

            if (turret.IsUnityNull())
            {
                Debug.Log("Cannot reference");
            }
            
            if (turrets_q.Count >= Stats.GetMaxTurrets())
            {
                Destroy(turrets_q.Dequeue());
            }

            turrets_q.Enqueue(Instantiate(turret, pos, new Quaternion()));
        }
    }
}
