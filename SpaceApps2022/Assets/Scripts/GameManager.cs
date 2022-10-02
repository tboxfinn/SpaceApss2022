using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //PanelControl
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text;
    //images Panel
    public GameObject panel;
    public GameObject PanelContent;
    public GameObject image;
    public GameObject image2;
    public static bool OnPanel;
    public Animator Panel_anim;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {


        //PanelControl

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Display(DataItems data)
    {
        panel.SetActive(true);
        Title_Text.text = data.itemName;
        Description_Text.text = data.itemDescription;
        image.GetComponent<Image>().sprite = data.itemImage;
        image2.GetComponent<Image>().sprite = data.itemImage2;
        PanelContent.SetActive(true);
        Time.timeScale = 0;
        OnPanel = true;
        timer = 0;

    }

    public void Closedisplay()
    {
        panel.SetActive(false);
        PanelContent.SetActive(false);

        Time.timeScale = 1;
        OnPanel = false;
    }
}
