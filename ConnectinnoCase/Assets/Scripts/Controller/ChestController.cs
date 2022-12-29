using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Lofelt.NiceVibrations;

public class ChestController : MonoBehaviour
{
    public int chestReward;
    public Animator chestAnim;
    public Image chestImage;
    public GameObject chestBackground;

    public Sprite chestOpen;
    public Sprite chestClose;
    
    


    public bool isOpen;
    private void Start()
    {
        ChestOpenCheck();
    }

    public void ChestOpenCheck()
    {
        chestImage.fillAmount = GameManager.Instance.jsonController.gameData.chestFill;
        if (GameManager.Instance.jsonController.gameData.chestOpenCount == 3)
        {
            isOpen = true;
            chestAnim.SetBool("Chest",true);
            chestBackground.SetActive(false);
            chestImage.sprite = chestOpen;
        }
        else
        {
            isOpen = false;
            chestAnim.SetBool("Chest",false);
            chestBackground.SetActive(true);
            chestImage.sprite = chestClose;
        }
    }

    public void OnClick()
    {
        var gm = GameManager.Instance;
        if (isOpen)
        {
            if (gm.isVibrationOn)
            {
                HapticPatterns.PlayPreset(HapticPatterns.PresetType.Success);
            }
           
            GameManager.Instance.soundManager.PlaySound(0);
            gm.jsonController.gameData.coinCount += chestReward;
            gm.uIManager.homeCointText.text = GameManager.Instance.jsonController.gameData.coinCount.ToString();
            gm.uIManager.inGameCointText.text = GameManager.Instance.jsonController.gameData.coinCount.ToString();
            isOpen = false;
            chestAnim.SetBool("Chest",false);
            chestImage.sprite = chestClose;
            gm.jsonController.gameData.chestOpenCount = 0;
            gm.jsonController.gameData.chestFill = 0;
            gm.jsonController.SaveData();
        }
    }
}
