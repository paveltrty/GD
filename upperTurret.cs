using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    private Rayshoot shoot;
    private float fireRate = 4;
    private float rotationSpeed = 10f;

    private float nextTimeToFire = 0f;
    private List<Collider> entered = new List<Collider>();
    private GameObject currTarget = null;
    private void Start()
    {
        shoot = GetComponent<Rayshoot>();
    }

    private void Update()
    {
        if (currTarget == null)
        {
            currTarget = selectNextTarget();
        }
        LookAt(currTarget);
        if (Time.time >= nextTimeToFire)
        {
            if (currTarget != null)
            {
                 nextTimeToFire += 1f / fireRate;
                 shoot.Shoot();
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Target tar = other.GetComponent<Target>();
        if (tar != null)
        {
            Debug.Log("entered");
            entered.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (entered.Contains(other))
        {
            entered.Remove(other);
        }

        if (other.gameObject == currTarget)
        {
            currTarget = null;
        }
    }

    private GameObject selectNextTarget()
    {
        if (entered.Count > 0)
        {
            Collider target = entered[0];
            entered.Remove(target);
            return target.GameObject();
        }
        return null;
    }

    private void LookAt(GameObject tar)
    {
        if (currTarget == null)
        {
            currTarget = selectNextTarget();
        }

        if (currTarget == null)
        {
            return;
        }
        Vector3 direction = tar.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 targetRotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime)
            .eulerAngles;
        transform.rotation = Quaternion.Euler(targetRotation);
    }
}
