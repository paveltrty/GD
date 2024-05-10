using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeStation : MonoBehaviour
{
   private void OnTriggerStay(Collider other)
   {
      if (other.transform.CompareTag("Player"))
      {
         GameObject canvas = other.gameObject.GetComponentInChildren<Camera>().GetComponentInChildren<UpgradeMenu>(true).gameObject;
         if (Input.GetKey("e"))
         {
            canvas.GameObject().SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      GameObject canvas = other.gameObject.GetComponentInChildren<Camera>().GetComponentInChildren<UpgradeMenu>(true).gameObject;
      canvas.GameObject().SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }
}
