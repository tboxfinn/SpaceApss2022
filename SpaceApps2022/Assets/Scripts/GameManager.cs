using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //PanelControl
    [SerializeField] private TextMeshProUGUI Title_Text, Description_Text;
    //images Panel
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
     
        
        //PanelControl

    }

    // Update is called once per frame
    void Update()
    {

        //PanelControl
        if (Jump.PanelControl == 1)
        {
            Mirror1();
        }
        else if (Jump.PanelControl == 2)
        {
            Mirror2();
        }
        else if (Jump.PanelControl == 3)
        {
            antenna();
        }
        else if (Jump.PanelControl == 4)
        {
            CTools();
        }
        else if (Jump.PanelControl == 5)
        {
            StabilizationFlap();
        }
        else if (Jump.PanelControl == 6)
        {
            SunGuard();
        }
        else if (Jump.PanelControl == 7)
        {
            SpaceshipPlatform();
        }

    }


    //PanelControl
    void Mirror1()
    {
        Title_Text.text = "Hola";
        Description_Text.text = "este es un texto de prueba. este es un texto de prueba. este es un texto de prueba. este es un texto de prueba. este es un texto de prueba";
    }
    void Mirror2()
    {

    }
    void antenna()
    {

    }
    void CTools()
    {

    }
    void StabilizationFlap()
    {

    }
    void SunGuard()
    {

    }
    void SpaceshipPlatform()
    {

    }

    public void Display()
    {
        if (Jump.index == 0)
        {
            images[0].gameObject.SetActive(true);
        }

        for(int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            images[Jump.index].gameObject.SetActive(true);
        }
    }
}
