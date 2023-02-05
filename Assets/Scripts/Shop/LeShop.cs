using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeShop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dentistText;
    [SerializeField] GameObject ItemButt1;
    [SerializeField] GameObject ItemButt2;
    [SerializeField] GameObject ItemButt3;
    [SerializeField] GameObject ItemButt4;
    [SerializeField] GameObject ItemButt5;
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
        bool downloadAHouse = false;
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
                    afford = false;
                    downloadAHouse = true;
                }
                break;
        }
        if (afford)
        {
            dentistText.text = "Thank you for your purchase!";
        }
        else if (downloadAHouse)
        {
            dentistText.tag = "I'll need the three funky numbers on the back.";
        }
        else
        {
            dentistText.text = "You can't afford that";
        }
        updateItems();
    }
    void updateItems()
    {
        ItemButt1.GetComponentInChildren<TextMeshProUGUI>().text = "E" + GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level);
        ItemButt2.GetComponentInChildren<TextMeshProUGUI>().text = "E" + GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level);
        ItemButt3.GetComponentInChildren<TextMeshProUGUI>().text = "E" + GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level);
        ItemButt4.GetComponentInChildren<TextMeshProUGUI>().text = "E" + GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level);
        ItemButt5.GetComponentInChildren<TextMeshProUGUI>().text = "£7,863,460.99";
    }
}
