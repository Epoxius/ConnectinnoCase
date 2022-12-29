using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public List<AudioClip> audioClips;
   public AudioSource audioSource;


   private void Start()
   {
      audioSource.volume = GameManager.Instance.jsonController.gameData.soundValue;
      GameManager.Instance.uIManager.soundSlider.value = GameManager.Instance.jsonController.gameData.soundValue;

      GameManager.Instance.uIManager.vibrationSlider.value =
         GameManager.Instance.jsonController.gameData.vibrationValue;
   }


   private void Update()
   {
      SoundVolumeCheck();
      VibrationControl();
   }

   public void SoundVolumeCheck()
   {
      if (GameManager.Instance.uIManager.soundSlider.value == 1)
      {
         GameManager.Instance.jsonController.gameData.soundValue = 1;
      }
      else if (GameManager.Instance.uIManager.soundSlider.value == 0)
      {
         GameManager.Instance.jsonController.gameData.soundValue = 0;
      }

      
     
      audioSource.volume = GameManager.Instance.jsonController.gameData.soundValue;
      GameManager.Instance.uIManager.soundSlider.value = GameManager.Instance.jsonController.gameData.soundValue;
   }
   public void PlaySound(int clipValue)
   {
      audioSource.clip = audioClips[clipValue];
      audioSource.Play();
   }

   public void VibrationControl()
   {
      if (GameManager.Instance.uIManager.vibrationSlider.value == 1)
      {
         GameManager.Instance.jsonController.gameData.vibrationValue = 1;
      }
      else if (GameManager.Instance.uIManager.vibrationSlider.value == 0)
      {
         GameManager.Instance.jsonController.gameData.vibrationValue = 0;
      }

      if (GameManager.Instance.jsonController.gameData.vibrationValue == 1 )
      {
         GameManager.Instance.isVibrationOn = true;
      }
      else if (GameManager.Instance.jsonController.gameData.vibrationValue == 0 )
      {
         GameManager.Instance.isVibrationOn = false;
      }
     
   }
}
