using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData
{

   public int levelCount;
   public int coinCount;
   public int chestOpenCount;
   public bool isNextLevel;
   

   public GameData(int levelCount, int coinCount, int chestOpenCount,bool isNextlevel)
   {
      this.levelCount = levelCount;
      this.coinCount = coinCount;
      this.chestOpenCount = chestOpenCount;
      this.isNextLevel = isNextlevel;
   }
}
