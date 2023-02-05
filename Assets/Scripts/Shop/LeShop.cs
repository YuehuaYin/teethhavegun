using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeShop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dentistText;
    [SerializeField] GameObject ItemButt1;
    [SerializeField] GameObject ItemButt2;
    [SerializeField] GameObject ItemButt3;
    [SerializeField] GameObject ItemButt4;
    [SerializeField] GameObject ItemButt5;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI dam;
    [SerializeField] TextMeshProUGUI rdam;


    [SerializeField] Sprite paste1;
    [SerializeField] Sprite paste2;
    [SerializeField] Sprite paste3;
    [SerializeField] Sprite paste4;
    [SerializeField] Sprite paste5;

    [SerializeField] Sprite mw1;
    [SerializeField] Sprite mw2;
    [SerializeField] Sprite mw3;
    [SerializeField] Sprite mw4;
    [SerializeField] Sprite mw5;

    [SerializeField] Sprite milk1;
    [SerializeField] Sprite milk2;
    [SerializeField] Sprite milk3;
    [SerializeField] Sprite milk4;
    [SerializeField] Sprite milk5;

    [SerializeField] Sprite Legs1;
    [SerializeField] Sprite Legs2;
    [SerializeField] Sprite legs3;
    [SerializeField] Sprite legs4;
    [SerializeField] Sprite legs5;

    [SerializeField] Image Item1;
    [SerializeField] Image Item2;
    [SerializeField] Image Item3;
    [SerializeField] Image Item4;

    [SerializeField] AudioSource sfx;
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
                if (GameStatistics.MONEY >= GameStatistics.item1BaseCost * Mathf.Pow(2f, GameStatistics.item1Level))
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
                if (GameStatistics.MONEY >= GameStatistics.item2BaseCost * Mathf.Pow(2f, GameStatistics.item2Level))
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
                if (GameStatistics.MONEY >= GameStatistics.item3BaseCost * Mathf.Pow(2f, GameStatistics.item3Level))
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
                if (GameStatistics.MONEY >= GameStatistics.item4BaseCost * Mathf.Pow(2f, GameStatistics.item4Level))
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
                    afford = false;
                    downloadAHouse = true;
                break;
        }
        if (afford)
        {
            sfx.Play();
            dentistText.text = "Thank you for your purchase!";
        }
        else if (downloadAHouse)
        {
            dentistText.text = "I'll need the three funky numbers on the back.";
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

        score.text = GameStatistics.maxScore.ToString();
        money.text = GameStatistics.MONEY.ToString();
        speed.text = GameStatistics.speed.ToString();
        dam.text = GameStatistics.damage.ToString();
        rdam.text = GameStatistics.rangeDamage.ToString();
        health.text = GameStatistics.maxHealth.ToString();

        switch (GameStatistics.item1Level)
        {
            case 0:
                Item1.sprite = paste1;
                break;
            case 1:
                Item1.sprite = paste2;
                break;
            case 2:
                Item1.sprite = paste3;
                break;
            case 3:
                Item1.sprite = paste4;
                break;
            case 4:
                Item1.sprite = paste5;
                break;
            case 5:
                Item1.enabled = false;
                ItemButt1.SetActive(false);
                break;
        }
        switch (GameStatistics.item2Level)
        {
            case 0:
                Item2.sprite = mw1;
                break;
            case 1:
                Item2.sprite =mw2;
                break;
            case 2:
                Item2.sprite = mw3;
                break;
            case 3:
                Item2.sprite = mw4;
                break;
            case 4:
                Item2.sprite = mw5;
                break;
            case 5:
                Item2.enabled = false;
                ItemButt2.SetActive(false);
                break;
        }
        switch (GameStatistics.item3Level)
        {
            case 0:
                Item3.sprite = milk1;
                break;
            case 1:
                Item3.sprite = milk2;
                break;
            case 2:
                Item3.sprite = milk3;
                break;
            case 3:
                Item3.sprite = milk4;
                break;
            case 4:
                Item3.sprite = milk5;
                break;
            case 5:
                Item3.enabled = false;
                ItemButt3.SetActive(false);
                break;
        }
        switch (GameStatistics.item4Level)
        {
            case 0:
                Item4.sprite = Legs1;
                break;
            case 1:
                Item4.sprite = Legs2;
                break;
            case 2:
                Item4.sprite = legs3;
                break;
            case 3:
                Item4.sprite = legs4;
                break;
            case 4:
                Item4.sprite = legs5;
                break;
            case 5:
                Item4.enabled = false;
                ItemButt4.SetActive(false);
                break;
        }
    }
    public void OnExitButt()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnContinueButt()
    {
        SceneManager.LoadScene("MainGame");
    }
}
