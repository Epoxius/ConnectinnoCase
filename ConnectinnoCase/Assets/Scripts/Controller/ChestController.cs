using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public Animator chestAnim;
    public Image chestImage;

    public Sprite chestOpen;
    public Sprite chestClose;
    

    public bool isOpen;
    private void Start()
    {
        ChestOpenCheck();
    }

    public void ChestOpenCheck()
    {
        if (GameManager.Instance.jsonController.gameData.chestOpenCount == 3)
        {
            isOpen = true;
            chestAnim.SetBool("Chest",true);
            chestImage.sprite = chestOpen;
        }
        else
        {
            isOpen = false;
            chestAnim.SetBool("Chest",false);
            chestImage.sprite = chestClose;
        }
    }

    private void OnClick()
    {
        if (isOpen)
        {
            
        }
    }
}
