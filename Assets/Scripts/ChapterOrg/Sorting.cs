using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sorting : MonoBehaviour
{
    public GameManager gameManager;


    public void RankSort()
    {
        Debug.Log("Clicked");
        GameObject charTab;
        Transform itemsChild;
        TextMeshProUGUI childsText;

        GameObject charTab2;
        Transform itemsChild2;
        TextMeshProUGUI childsText2;

        foreach (var item in gameManager.unitTable)
        {
            charTab = gameManager.unitTable[item.Key];
            itemsChild = charTab.transform.Find("Rank");
            childsText = itemsChild.GetComponent<TextMeshProUGUI>();

            if (childsText.text == "Scout")
            {
            }
        }
    }
}
