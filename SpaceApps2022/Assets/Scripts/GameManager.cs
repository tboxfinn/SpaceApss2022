using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //PanelControl
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text, TitleText2, DescriptionText2, piecesText;
    public int pieces;
 
    //images Panel & Game Panel
    public GameObject GamePanel, MenuPanel, PausePanel, PanelWin, image, image2,SecondImage, Congratulations, panel, PanelContent;
    public static bool OnPanel, OnPause, OnMenu, OnGame;
    public Animator Panel_anim;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);

        //PanelControl
        panel.SetActive(false);
        PanelContent.SetActive(false);
        PanelWin.SetActive(false);

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

        if (Input.GetKeyDown(KeyCode.Escape) && OnPause ==true)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && OnPause == false)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Display(DataItems data)
    {
        pieces += 1;
        panel.SetActive(true);
        Title_Text.text = data.itemName;
        Description_Text.text = data.itemDescription;
        image.GetComponent<Image>().sprite = data.itemImage;
        image2.GetComponent<Image>().sprite = data.itemImage2;
        if (pieces != 8)
        {
            PanelContent.SetActive(true);
        }
        Time.timeScale = 0;
        OnPanel = true;
        if (pieces >= 8)
        {
            PanelWin.SetActive(true);
            TitleText2.text = data.itemName;
            DescriptionText2.text = data.itemDescription;
            SecondImage.GetComponent<Image>().sprite = data.itemImage;

        }
        piecesText.text = pieces + "/7";
        GamePanel.SetActive(false);

    }
    public void Closedisplay()
    {
        panel.SetActive(false);
        PanelContent.SetActive(false);
        PanelWin.SetActive(false);

        Time.timeScale = 1;
        OnPanel = false;
        GamePanel.SetActive(true);
    }

    public void Pause()
    {
        if (OnPause == true)
        {
            Game();
        }
        else if (OnPause == false)
        {
            PausePanel.SetActive(true);
        }
    }

    public void Game()
    {

    }

    public void Menu()
    {

    }
}
