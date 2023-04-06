using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharAttributes : MonoBehaviour
{
    public int characterExperience;

    public string characterName;
    public string characterType;
    public string characterRank;
    public string characterCompany;

    public Texture characterIcon;

    void Start()
    {
        // getting relevant info from the character
        characterExperience = 0;

        GettingCharInfo();
    }

    void GettingCharInfo()
    {
        Transform child;
        RawImage childsImage;
        TextMeshProUGUI childsText;

        child = gameObject.transform.Find("TypeImage");
        childsImage = child.GetComponent<RawImage>();
        characterIcon = childsImage.texture;

        child = gameObject.transform.Find("Name");
        childsText = child.GetComponent<TextMeshProUGUI>();
        characterName += childsText.text;
        
        child = gameObject.transform.Find("Type");
        childsText = child.GetComponent<TextMeshProUGUI>();
        characterType += childsText.text;

        child = gameObject.transform.Find("Rank");
        childsText = child.GetComponent<TextMeshProUGUI>();
        characterRank += childsText.text;

        child = gameObject.transform.Find("Company");
        childsText = child.GetComponent<TextMeshProUGUI>();
        characterCompany += childsText.text;
    }
}
