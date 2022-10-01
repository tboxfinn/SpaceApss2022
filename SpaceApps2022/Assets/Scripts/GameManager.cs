using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameObject JWST_Panel;
    public static GameObject Mirror_Image;
    public static TextMeshProUGUI Title_Text, Description_Text;
    public static bool IsJWSTPanelHide;
    // Start is called before the first frame update
    void Start()
    {
        //JamesWebbPanels
        JWST_Panel = GameObject.FindGameObjectWithTag("Panel JWST");
        Mirror_Image = GameObject.FindGameObjectWithTag("Mirror_Tag");
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void Display_JWSTPanel()
    {
        if (IsJWSTPanelHide == true)
        {
            JWST_Panel.SetActive(true);
            IsJWSTPanelHide = false;
        }
        else if (IsJWSTPanelHide == false)
        {
            JWST_Panel.SetActive(false);
            IsJWSTPanelHide = true;
        }

        JamesWebb_Mirror();
    }

    public void JamesWebb_Mirror()
    {
        Title_Text.text = "Bakugo";
        Description_Text.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
    }
}
