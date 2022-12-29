using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData
{

   public int levelCount;
   public int coinCount;
   public int chestOpenCount;
   public float chestFill;
   public bool isNextLevel;
   public int vibrationValue;
   public int soundValue;
   

   public GameData(int levelCount, int coinCount, int chestOpenCount,float chestFill,bool isNextlevel,int soundValue,int vibrationValue)
   {
      this.levelCount = levelCount;
      this.coinCount = coinCount;
      this.chestOpenCount = chestOpenCount;
      this.chestFill = chestFill;
      this.isNextLevel = isNextlevel;
      this.soundValue = soundValue;
      this.vibrationValue = vibrationValue;
   }
}
