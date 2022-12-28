using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public int chestReward;
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

    public void OnClick()
    {
        var gm = GameManager.Instance;
        if (isOpen)
        {
            gm.jsonController.gameData.coinCount += chestReward;
            gm.uIManager.homeCointText.text = GameManager.Instance.jsonController.gameData.coinCount.ToString();
            gm.uIManager.inGameCointText.text = GameManager.Instance.jsonController.gameData.coinCount.ToString();
            isOpen = false;
            chestAnim.SetBool("Chest",false);
            chestImage.sprite = chestClose;
            gm.jsonController.gameData.chestOpenCount = 0;
            gm.jsonController.SaveData();
        }
    }
}
