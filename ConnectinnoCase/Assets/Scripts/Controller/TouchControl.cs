using System;
using DG.Tweening;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

   float doubleClickTime = 0.5f;
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
            var pan = GameManager.Instance.pan;
            if (hitInfo.transform.gameObject.CompareTag("Fruit"))
            {
               if (Time.time - lastMouseDownTime <= doubleClickTime)
               {
               }

               
               
               lastMouseDownTime = Time.time;
               
            } else {
           //    Debug.Log ("nopz");
            }
         } else {
          //  Debug.Log("No hit");
         }
         //Debug.Log("Mouse is down");
      } 
   }
}