using System;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

   float doubleClickTime = 0.5f;

// Time of last mouse button down event
   float lastMouseDownTime = 0;
   public int clickCount;


   private void FixedUpdate()
   {
      SelectFruit();
   }

   public void SelectFruit()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Debug.Log("Mouse is down");
         
         RaycastHit hitInfo = new RaycastHit();
         bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
         if (hit) 
         {
            if (hitInfo.transform.gameObject.CompareTag("Fruit"))
            {
               if (Time.time - lastMouseDownTime <= doubleClickTime)
               {
               }

               
               
               lastMouseDownTime = Time.time;
               
            } else {
               Debug.Log ("nopz");
            }
         } else {
            Debug.Log("No hit");
         }
         Debug.Log("Mouse is down");
      } 
   }
}