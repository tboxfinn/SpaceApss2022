using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //PanelControl
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text, TitleText2, DescriptionText2;
    //images Panel
    public GameObject panel, PanelContent, PanelWin, image, image2,SecondImage, SecondImage2, Congratulations;
    public static bool OnPanel;
    public Animator Panel_anim;
    public int pieces;
    // Start is called before the first frame update
    void Start()
    {


        //PanelControl

    }

    // Update is called once per frame
    void Update()
    {
        if (pieces == 7)
        {
            Congratulations.SetActive(true);
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
            SecondImage2.GetComponent<Image>().sprite = data.itemImage2;

        }

    }
    public void Closedisplay()
    {
        panel.SetActive(false);
        PanelContent.SetActive(false);

        Time.timeScale = 1;
        OnPanel = false;
    }
}
