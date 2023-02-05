using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    public static int damage = 50;
    public static int rangeDamage = 35;
    public static int maxHealth = 5;
    public static float speed = 5f;
    public static int skin = 1;

    public static int maxScore;
    public static int runScore;
    //check the score at end of main game scene, add at end of cutscene scene, only go to that scene if you have enough score to view one.
    public static int NextCutscene;


    public static int MONEY;

    public static int item1Level = 1;
    public static int item2Level = 1;
    public static int item3Level = 1;
    public static int item4Level = 1;
    public static int item5Level = 1;

    public static int item1BaseCost = 500;
    public static int item2BaseCost = 500;
    public static int item3BaseCost = 500;
    public static int item4BaseCost = 500;
    public static int item5BaseCost = 10000;
    public static int item5Cost2 = 250000;
    public static int item5cost3 = 5000000;

    public static int jEnemy = 100;
    public static int bEnemy = 200;
    public static int tEnemy = 300;
}
