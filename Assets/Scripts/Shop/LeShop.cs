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
        updateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyItem(int n)
    {
        bool afford = true;
        switch (n)
        {
            case 1:
                if (GameStatistics.MONEY > GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level));
                    GameStatistics.damage += 30;
                    GameStatistics.item1Level += 1;
                }
                else
                {
                    afford = false;
                }
                break;
            case 2:
                if (GameStatistics.MONEY > GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level));
                    GameStatistics.rangeDamage += 20;
                    GameStatistics.item2Level += 1;
                }
                else
                {
                    afford = false;
                }
                break;
            case 3:
                if (GameStatistics.MONEY > GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level));
                    GameStatistics.maxHealth += 1;
                    GameStatistics.item3Level += 1;
                }
                else
                {
                    afford = false;
                }
                break;
            case 4:
                if (GameStatistics.MONEY > GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level));
                    GameStatistics.speed += 1.5f;
                    GameStatistics.item4Level += 1;
                }
                else
                {
                    afford = false;
                }
                break;
            case 5:
                if (GameStatistics.MONEY > GameStatistics.item5BaseCost * Mathf.Pow(2f, GameStatistics.item5Level))
                {
                    GameStatistics.MONEY -= Mathf.RoundToInt(GameStatistics.item5BaseCost * Mathf.Pow(2f, GameStatistics.item5Level));
                    GameStatistics.skin += 1;
                    GameStatistics.item5Level += 1;
                }
                else
                {
                    afford = false;
                }
                break;
        }
        if (afford)
        {
            dentistText.text = "Thank you for your purchase!";
        }
        else
        {
            dentistText.text = "You can't afford that";
        }
        updateItems();
    }
    void updateItems()
    {

    }
}
