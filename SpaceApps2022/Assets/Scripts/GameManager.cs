using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Panels
    public GameObject GamePanel, MenuPanel, PausePanel, InfoPanel, PanelContent, GalleryPanel, ControlPanel;
    //Panel Content
    public GameObject PanelWin, image, image2, imageWin, ItemWin, Player, SpanishBtnMenu, EnglishBtnMenu, SpanishBtnPause, EnglishBtnPause;
    public GameObject[] GalleryBackground;
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text, TitleTextWin, DescriptionTextWin, piecesText, MenuTitle, TitleGallery, TitleGamePanel,Description1GamePanel, Description2GamePanel;

    //Other Stuff
    public static bool OnPanel, OnPause, OnMenu, OnGame, SpanishBool;
    public int pieces, GalleryIndex;
    public Animator Panel_anim;
    public string GameStat;

    // Start is called before the first frame update
    void Start()
    {
        Spanish();
        GameStat = "InMenu";
        MenuPanel.SetActive(true);
        PausePanel.SetActive(false);
        GalleryPanel.SetActive(false);
        GalleryIndex = 0;

        //PanelControl
        InfoPanel.SetActive(false);
        PanelContent.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (pieces == 7)
        {
            ItemWin.SetActive(true);
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

        //Gallery
        if (GalleryIndex > 6)
            GalleryIndex = 0;
        else if (GalleryIndex < 0)
            GalleryIndex = 6;

        if (GameStat == "InMenu")
        {
            //items.SpawnItems();
            Time.timeScale = 1f;
            Player.SetActive(false);
            //Panel Control
            MenuPanel.SetActive(true);
            PausePanel.SetActive(false);
            GamePanel.SetActive(false);
            GalleryPanel.SetActive(false);
            ControlPanel.SetActive(false);
        }
        else if (GameStat == "InGame")
        {
            Time.timeScale = 1f;
            Player.SetActive(true);
            //Panel Control
            MenuPanel.SetActive(false);
            PausePanel.SetActive(false);
            GamePanel.SetActive(true);
            ControlPanel.SetActive(false);
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
            PanelWin.SetActive(false);
            if (pieces >= 8)
                PanelWin.SetActive(true);
            else if (pieces < 8)
                PanelWin.SetActive(false);
        }
        else if (GameStat == "InGallery")
        {
            GalleryPanel.SetActive(true);
            if (SpanishBool == true)
            {
                TitleGallery.text = "capturas del James webb";
            }
            else if (SpanishBool == false)
            {
                TitleGallery.text = "james webb's captures";
            }

            if (GalleryIndex == 0)
            {
                GalleryBackground[0].gameObject.SetActive(true);
            }
        }
        else if (GameStat == "ControlPanel")
        {
            ControlPanel.SetActive(true);
            GamePanel.SetActive(false);
            MenuPanel.SetActive(false);
            if (SpanishBool == true)
            {
                TitleGamePanel.text = "Controles de Juego";
                Description1GamePanel.text = "Movimiento del Jugador";
                Description2GamePanel.text = "Salto del Jugador: manten presionado para cargar fuerza de Saldto";
            }
            else if (SpanishBool == false)
            {
                TitleGamePanel.text = "Game Controllers";
                Description1GamePanel.text = "Player Movement";
                Description2GamePanel.text = "player Jump: Hold down to charge Jump Force";
            }
        }
    }

    public void GalleryNext()
    {
        GalleryIndex += 1;

        for (int i = 0;i < GalleryBackground.Length; i++)
        {
            GalleryBackground[i].gameObject.SetActive(false);
            GalleryBackground[GalleryIndex].gameObject.SetActive(true);
        }

        Debug.Log(GalleryIndex);
    }

    public void GalleryPrevious()
    {
        GalleryIndex -= 1;

        for (int i = 0; i < GalleryBackground.Length; i++)
        {
            GalleryBackground[i].gameObject.SetActive(false);
            GalleryBackground[GalleryIndex].gameObject.SetActive(true);
        }

        Debug.Log(GalleryIndex);
    }

    public void Display(DataItems data)
    {
        pieces += 1;

        //Booleano del español, si es true entonces el idioma del contenido será del español
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

        //Si las piezas son mayores o iguales a 8, entonces mostrará la pantalla de victoria
        if (pieces >= 8)
        {
            PanelWin.SetActive(true);
            if (SpanishBool == false)
            {
                TitleTextWin.text = data.itemName;
                DescriptionTextWin.text = data.itemDescription;
            }
            else if (SpanishBool == true)
            {
                TitleTextWin.text = data.ItemNameSpanish;
                DescriptionTextWin.text = data.itemDescriptionSpanish;
            }
            imageWin.GetComponent<Image>().sprite = data.itemImage;

        }
        piecesText.text = pieces + "/7";
        GamePanel.SetActive(false);
        GameStat = "InfoPanel";

    }


    //cierra el panel de información
    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
        PanelContent.SetActive(false);
        PanelWin.SetActive(false);
        GameStat = "InGame";
        InGame();
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
        SceneManager.LoadScene("Main");
    }
    public void Pause()
    {
        GameStat = "InPause";
    }
    public void OpenGallery()
    {
        GameStat = "InGallery";
    }
    public void OncontrolPanel()
    {
        GameStat = "ControlPanel";
    }

    public void ExitGame()
    {
        Application.Quit();
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
