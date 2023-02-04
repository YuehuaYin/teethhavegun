using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    Queue<(int, string)> text;
    [SerializeField] GameObject Textbox1;
    [SerializeField] GameObject Textbox2;
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject ShopButton;
    // Start is called before the first frame update
    void Start()
    {
        text = new Queue<(int,string)>(Events.getCutscene(GameStatistics.NextCutscene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextClick()
    {
        if (text.Count == 0)
        {
            cutsceneEnd();
        }
        else
        {
            var temp = text.Dequeue();
            if (temp.Item1 == 1)
            {
                Textbox1.GetComponent<TextMeshProUGUI>().text = temp.Item2;
            }
            else
            {
                Textbox2.GetComponent<TextMeshProUGUI>().text = temp.Item2;
            }
        }
    }
    void cutsceneEnd()
    {
        ShopButton.GetComponent<ShopButt>().Enable();
    }
    void leaveScene()
    {
        GameStatistics.NextCutscene = GameStatistics.NextCutscene + 1;
        SceneManager.LoadScene("Shop");
    }
}
