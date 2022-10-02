using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New part", menuName = "Parte del Telescopio")]
public class DataItems : ScriptableObject
{
    public string itemName;
    public string ItemNameSpanish;
    public string itemDescription;
    public string itemDescriptionSpanish;
    public Sprite itemImage;
    public Sprite itemImage2;
}
