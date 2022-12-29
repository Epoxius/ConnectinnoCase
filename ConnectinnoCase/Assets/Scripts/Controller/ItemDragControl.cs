using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Lofelt.NiceVibrations;
public class ItemDragControl : MonoBehaviour
{
    [Header("Drag Ref")] private Vector3 mOffset;
    private float mZCoord;

    [Header("Double Click Ref")] float doubleClickTime = 0.5f;
    float lastMouseDownTime = 0;

    [Header("State Ref")] public CorrectCheckController correctCheckController;
    public bool isChoosen;

    public FruitType fruitType;


    #region DragControl

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
        
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        DoubleClick();
    }

    public void DoubleClick()
    {
        if (Time.time - lastMouseDownTime <= doubleClickTime)
        {
            isChoosen = true;


            if (GameManager.Instance.isVibrationOn)
            {
                HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
            }
           
            GameManager.Instance.soundManager.PlaySound(3);
            transform.DOJump(
                    GetRandomPositionOnPan(), 2, 1,
                    1)
                .OnComplete(
                    () =>
                    {
                        correctCheckController.CheckisDoneControl();
                        correctCheckController.CheckIn(fruitType);
                        GameManager.Instance.levelManager.LevelControl(fruitType,correctCheckController.isDone);
                    });
        }
        else
        {
            if (GameManager.Instance.isVibrationOn)
            {
                HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
            }
            GameManager.Instance.soundManager.PlaySound(2); 
        }

        lastMouseDownTime = Time.time;
    }


    private Vector3 GetMouseAsWorldPoint()

    {
        Vector3 mousePoint = Input.mousePosition;


        mousePoint.z = mZCoord;


        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    public void PosClamp()
    {
        if (!isChoosen)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                Mathf.Clamp(transform.position.z, -1.3f, 3));
        }
    }

  

    #endregion
    Vector3 GetRandomPositionOnPan()
    {
        var pan = GameManager.Instance.pan;

        float minX = pan.position.x - pan.localScale.x / 4;
        float maxX = pan.position.x + pan.localScale.x / 4;
        float minZ = pan.position.z - pan.localScale.z / 4;
        float maxZ = pan.position.z + pan.localScale.z / 4;


        float x = Random.Range(minX, maxX);
        float y = pan.position.y + 1;
        float z = Random.Range(minZ, maxZ);
        return new Vector3(x, y, z);
    }
   
}