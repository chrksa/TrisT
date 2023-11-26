using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    
    private bool isUnlocked = false;

    [SerializeField] public GameObject com;
    [SerializeField] public static bool[] Unlocks = { false, false, false, false, false, false };
    private TextMeshProUGUI text;
    [SerializeField] public Button[] buttons;
    [SerializeField] public Sprite[] unlockedSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        text = com.GetComponent<TextMeshProUGUI>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Unlocks[5])
        {
            buttons[5].GetComponent<Image>().overrideSprite = unlockedSprite[5];
        }
    }

    public void Achievment1Text()
    {
        if (Unlocks[0] == true)
        {
            text.text = "1";
        }
        else
        {
            text.text = "locked...";
        }
    }
    
    public void Achievment2Text()
    {
        if (Unlocks[1] == true)
        {
            text.text = "2";
        }
        else
        {
            text.text = "locked...";
        }
    }
    public void Achievment3Text()
    {
        if (Unlocks[2] == true)
        {
            text.text = "3";
        }
        else
        {
            text.text = "locked...";
        }
    }
    public void Achievment4Text()
    {
        if (Unlocks[3] == true)
        {
            text.text = "4";
        }
        else
        {
            text.text = "locked...";
        }
    }
    public void Achievment5Text()
    {
        if (Unlocks[4] == true)
        {
            text.text = "5";
        }
        else
        {
            text.text = "locked...";
        }
    }
    public void Achievment6Text()
    {
        if (Unlocks[5] == true)
        {
            text.text = "Click the Amogus";
        }
        else
        {
            text.text = "locked...";
        }
    }

    public void AmogusButton()
    {
        Unlocks[5] = true;
        buttons[5].GetComponent<Image>().overrideSprite = unlockedSprite[5];
        
    }
    
}
