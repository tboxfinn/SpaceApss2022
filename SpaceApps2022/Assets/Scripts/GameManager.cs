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
    public GameObject image;
    public static bool OnPanel;

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
        Title_Text.text = data.itemName;
        Description_Text.text = data.itemDescription;
        image.GetComponent<Image>().sprite = data.itemImage;
        panel.SetActive(true);
        Time.timeScale = 0;
        OnPanel = true;
    }

    public void Closedisplay()
    {
        panel.SetActive(false);

        Time.timeScale = 1;
        OnPanel = false;
    }
}
