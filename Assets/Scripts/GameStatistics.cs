using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    public static int damage = 50;
    public static int rangeDamage = 35;
    public static int maxHealth = 5;
    public static float speed = 5f;

    public static int maxScore;
    public static int runScore;
    //check the score at end of main game scene, add at end of cutscene scene, only go to that scene if you have enough score to view one.
    public static int NextCutscene;

    public static int MONEY = 0;

    public static int item1Level = 0;
    public static int item2Level = 0;
    public static int item3Level = 0;
    public static int item4Level = 0;
    public static int item5Level = 0;

    public static int item1BaseCost = 30;
    public static int item2BaseCost = 30;
    public static int item3BaseCost = 30;
    public static int item4BaseCost = 30;


    public static int jEnemy = 100;
    public static int bEnemy = 200;
    public static int tEnemy = 300;

    public static void reset()
    {
        damage = 50;
        rangeDamage = 35;
        maxHealth = 5;
        speed = 5f;
        MONEY = 0;
        item1Level = 1;
        item2Level = 1;
        item3Level = 1;
        item4Level = 1;
        item5Level = 1;

    }
}
