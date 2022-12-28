using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemDragControl : MonoBehaviour
{
    [Header("Drag Ref")] private Vector3 mOffset;
    private float mZCoord;

    [Header("Double Click Ref")] float doubleClickTime = 0.5f;
    float lastMouseDownTime = 0;

    [Header("State Ref")] public CorrectCheckController correctCheckController;
    public bool isChoosen;


    public FruitType fruitType;

    private void Update()
    {
        //  PosClamp();
    }

    #region DragControl

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;


        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        if (Time.time - lastMouseDownTime <= doubleClickTime)
        {
            isChoosen = true;


            transform.DOJump(
                    GetRandomPositionOnPan(), 1, 1,
                    1)
                .OnComplete(
                    () =>
                    {
                        correctCheckController.Check(fruitType);
                        GameManager.Instance.levelManager.LevelControl(fruitType);
                    });
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

    Vector3 GetRandomPositionOnPan()
    {
        var pan = GameManager.Instance.pan;

        float minX = pan.position.x - pan.localScale.x / 6;
        float maxX = pan.position.x + pan.localScale.x / 6;
        float minZ = pan.position.z - pan.localScale.z / 6;
        float maxZ = pan.position.z + pan.localScale.z / 6;


        float x = Random.Range(minX, maxX);
        float y = pan.position.y + 1;
        float z = Random.Range(minZ, maxZ);
        return new Vector3(x, y, z);
    }

    #endregion
}