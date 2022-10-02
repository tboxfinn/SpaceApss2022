using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //PanelControl
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text, TitleText2, DescriptionText2, piecesText, MenuTitle;
    public int pieces;
 
    //images Panel & Game Panel
    public GameObject GamePanel, MenuPanel, PausePanel, PanelWin, image, image2,SecondImage, Congratulations, InfoPanel, PanelContent, Player, SpanishBtnMenu, EnglishBtnMenu, SpanishBtnPause, EnglishBtnPause;
    public static bool OnPanel, OnPause, OnMenu, OnGame, SpanishBool;
    public Animator Panel_anim;
    public static string GameStat;
    //images Panel
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        Spanish();
        GameStat = "InMenu";
        MenuPanel.SetActive(true);
        PausePanel.SetActive(false);

        //PanelControl
        InfoPanel.SetActive(false);
        PanelContent.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (pieces == 7)
        {
            Congratulations.SetActive(true);
        }
        else if (pieces >= 8)
        {
            piecesText.text = "7/7";
        }

        //GameStat
        if (Input.GetKeyDown(KeyCode.Escape) && GameStat == "InGame")
        {
            GameStat = "InPause";
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameStat == "InPause")
        {
            GameStat = "InGame";
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameStat == "InMenu")
        {
            GameStat = "InMenu";
        }

        if (GameStat == "InMenu")
        {
            Time.timeScale = 1f;
            Player.SetActive(false);
            //Panel Control
            MenuPanel.SetActive(true);
            PausePanel.SetActive(false);
            GamePanel.SetActive(false);
        }
        else if (GameStat == "InGame")
        {
            Time.timeScale = 1f;
            Player.SetActive(true);
            //Panel Control
            MenuPanel.SetActive(false);
            PausePanel.SetActive(false);
            GamePanel.SetActive(true);
        }
        else if (GameStat == "InPause")
        {
            Time.timeScale = 0f;

            //Panel Control
            MenuPanel.SetActive(false);
            PausePanel.SetActive(true);
            GamePanel.SetActive(false);
        }
        else if (GameStat == "InfoPanel")
        {
            Time.timeScale = 0;
            InfoPanel.SetActive(true);
            OnPanel = true;
        }
    }

    public void Display(DataItems data)
    {
        pieces += 1;
        if (SpanishBool == false)
        {
            Title_Text.text = data.itemName;
            Description_Text.text = data.itemDescription;
        }
        else if (SpanishBool == true)
        {
            Title_Text.text = data.ItemNameSpanish;
            Description_Text.text = data.itemDescriptionSpanish;
        }
        image.GetComponent<Image>().sprite = data.itemImage;
        image2.GetComponent<Image>().sprite = data.itemImage2;
        if (pieces != 8)
        {
            PanelContent.SetActive(true);
        }

        if (pieces >= 8)
        {
            PanelWin.SetActive(true);
            if (SpanishBool == false)
            {
                TitleText2.text = data.itemName;
                DescriptionText2.text = data.itemDescription;
            }
            else if (SpanishBool == true)
            {
                TitleText2.text = data.ItemNameSpanish;
                DescriptionText2.text = data.itemDescriptionSpanish;
            }
            SecondImage.GetComponent<Image>().sprite = data.itemImage;

        }
        piecesText.text = pieces + "/7";
        GamePanel.SetActive(false);
        GameStat = "InfoPanel";

    }
    public void Closedisplay()
    {
        InfoPanel.SetActive(false);
        PanelContent.SetActive(false);
        PanelWin.SetActive(false);
        GameStat = "InGame";

        Time.timeScale = 1;
        OnPanel = false;
        GamePanel.SetActive(true);
    }

    public void InGame()
    {
        GameStat = "InGame";
    }
    public void InMenu()
    {
        GameStat = "InMenu";
    }
    public void Pause()
    {
        GameStat = "InPause";
    }

    public void English()
    {
        EnglishBtnMenu.SetActive(false);
        SpanishBtnMenu.SetActive(true);
        EnglishBtnPause.SetActive(false);
        SpanishBtnPause.SetActive(true);
        SpanishBool = false;
        MenuTitle.text = "webb's journey";
    }

    public void Spanish()
    {
        SpanishBtnPause.SetActive(false);
        EnglishBtnPause.SetActive(true);
        SpanishBtnMenu.SetActive(false);
        EnglishBtnMenu.SetActive(true);
        SpanishBool = true;
        MenuTitle.text = "el viaje de webb";
    }
}
