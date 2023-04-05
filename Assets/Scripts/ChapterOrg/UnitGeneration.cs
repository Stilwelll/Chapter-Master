using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitGeneration : MonoBehaviour
{
    public RandomUnitTypes randomUnitTypes;
    public GameManager gameManager;

    private Vector3 charOffset;

    public GameObject spaceMarineChar;
    public GameObject content;

    private float charOffsetYValue = 323.02f + 104.04f;
    public int charCount;

    void Awake()
    {
        // declaring the offset for the character tabs y-value
        charOffset = new Vector3(8.15f + 734.35f + 8, charOffsetYValue, 0);

        // getting a random number between either number to populate the character list
        // also setting the charcount to that initial char count
        int startingCharCount = Random.Range(10, 20);
        charCount = startingCharCount;

        ContentBoxAdjust();

        // populating the list with the amount generated above. also increasing the offset with each 
        // -character generated
        for (int i = 0; i < startingCharCount + 1; i++)
        {
            Instantiate(spaceMarineChar, charOffset, spaceMarineChar.transform.rotation, content.transform);
            charOffset = new Vector3(8.15f + 734.35f + 8.0f, charOffsetYValue - 145.65f, 0);
            charOffsetYValue = charOffset.y;
        }

        RenameCharTabs();
        CharTabInfoPop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RenameCharTabs()
    {
        GameObject[] charTabClones = GameObject.FindGameObjectsWithTag("CharTab");

        // renaming and adding all units to the unit table
        for (int i = 0; i < charTabClones.Length; i++)
        {
            charTabClones[i].name = "SpaceMarineChar" + i;
            gameManager.unitTable.Add(charTabClones[i].GetInstanceID(), charTabClones[i]);
        }
    }

    void CharTabInfoPop()
    {
        // populating the Character Tabs with info
        GameObject charTab;
        TextMeshProUGUI childsText;
        Transform itemsChild;
        Transform itemsChild2;

        Texture2D[] icons = randomUnitTypes.typeIcons;

        int rankCountSergeant = 0;
        int randomUnitIndex;
        int randomUnitIndex2;
        foreach (var item in gameManager.unitTable)
        {
            // Randomly choosing the names

            charTab = gameManager.unitTable[item.Key];
            itemsChild = charTab.transform.Find("Name");
            childsText = itemsChild.GetComponent<TextMeshProUGUI>();

            randomUnitIndex = Random.Range(0, randomUnitTypes.firstName.Length - 1);
            randomUnitIndex2 = Random.Range(0, randomUnitTypes.firstName.Length - 1);

            childsText.text = randomUnitTypes.firstName[randomUnitIndex] + " " + randomUnitTypes.lastName[randomUnitIndex2];

            // Randomly choosing the type
            charTab = gameManager.unitTable[item.Key];
            itemsChild = charTab.transform.Find("Type");
            childsText = itemsChild.GetComponent<TextMeshProUGUI>();

            randomUnitIndex = Random.Range(0, randomUnitTypes.standardTypes.Length - 1);
            childsText.text = randomUnitTypes.standardTypes[randomUnitIndex];

            // Setting Type Image
            itemsChild2 = charTab.transform.Find("TypeImage");
            RawImage childsImage = itemsChild2.GetComponent<RawImage>();
            if (childsText.text == "Assault")
            {
                childsImage.texture = icons[0];
            }
            else if (childsText.text == "Devastator")
            {
                childsImage.texture = icons[2];
            }
            else if (childsText.text == "Tactical")
            {
                childsImage.texture = icons[3];
            }

            //======================================================
            // Randomly choosing the company
            charTab = gameManager.unitTable[item.Key];
            itemsChild = charTab.transform.Find("Company");
            childsText = itemsChild.GetComponent<TextMeshProUGUI>();

            randomUnitIndex = Random.Range(0, randomUnitTypes.companies.Length - 1);
            childsText.text = randomUnitTypes.companies[randomUnitIndex];

            // Randomly choosing the rank
            charTab = gameManager.unitTable[item.Key];
            itemsChild = charTab.transform.Find("Rank");
            childsText = itemsChild.GetComponent<TextMeshProUGUI>();

            randomUnitIndex = Random.Range(0, randomUnitTypes.ranks.Length);
            if (randomUnitIndex == 3)
            {
                rankCountSergeant++;
            }

            // if there are more than 3 sergeants, than the units rank will be Brother
            if (rankCountSergeant > 4)
            {
                childsText.text = randomUnitTypes.ranks[1];  
            }
            else
            {
                childsText.text = randomUnitTypes.ranks[randomUnitIndex];
            }

            // Setting veteran rank image
            if (childsText.text == "Veteran")
            {
                childsImage.texture = icons[4];
            }

            if (childsText.text == "Sergeant")
            {
                childsImage.texture = icons[1];
            }
        }
    }

    void ContentBoxAdjust()
    {
        RectTransform contentBox;
        contentBox = content.GetComponent<RectTransform>();

        if (charCount > 6)
        {
            float previousSize = 145.65f * charCount;
            // contentBox.TransformDirection(Vector3.down * previousSize);
            // // contentBox.sizeDelta = new Vector2(contentBox.sizeDelta.x, contentBox.sizeDelta.y + previousSize);
        }
    }
}
