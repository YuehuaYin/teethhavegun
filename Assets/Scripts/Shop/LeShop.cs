using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeShop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dentistText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyItem(int n)
    {
        switch (n)
        {
            case 1:
                if (GameStatistics.MONEY > GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level));
                    //GIVE ITEM EFFECT
                }
                break;
            case 2:
                if (GameStatistics.MONEY > GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level));
                    //GIVE ITEM EFFECT
                }
                break;
            case 3:
                if (GameStatistics.MONEY > GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level));
                    //GIVE ITEM EFFECT
                }
                break;
            case 4:
                if (GameStatistics.MONEY > GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level));
                    //GIVE ITEM EFFECT
                }
                break;
            case 5:
                if (GameStatistics.MONEY > GameStatistics.item5BaseCost * Mathf.Pow(2f, GameStatistics.item5Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item5BaseCost * Mathf.Pow(2f, GameStatistics.item5Level));
                    //GIVE ITEM EFFECT
                }
                break;
            case 6:
                if (GameStatistics.MONEY > GameStatistics.item6BaseCost * Mathf.Pow(2f, GameStatistics.item6Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item6BaseCost * Mathf.Pow(2f, GameStatistics.item6Level));
                    //GIVE ITEM EFFECT
                }
                break;

        }
    }
}
