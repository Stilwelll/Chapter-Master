using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        charOffset = new Vector3(8.15f + 734.35f + 8, charOffsetYValue, 0);

        int startingCharCount = Random.Range(5, 10);
        charCount = startingCharCount;

        for (int i = 0; i < startingCharCount + 1; i++)
        {
            Instantiate(spaceMarineChar, charOffset, spaceMarineChar.transform.rotation, content.transform);
            charOffset = new Vector3(8.15f + 734.35f + 8.0f, charOffsetYValue - 145.65f, 0);
            charOffsetYValue = charOffset.y;
        }
        RenameCharTabs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RenameCharTabs()
    {
        GameObject[] charTabClones = GameObject.FindGameObjectsWithTag("CharTab");

        for (int i = 0; i < charTabClones.Length; i++)
        {
            charTabClones[i].name = "SpaceMarineChar" + i;
            gameManager.unitTable.Add(charTabClones[i]);
        }
        int lastIndex = gameManager.unitTable.Count - 1;
        gameManager.unitTable.RemoveAt(lastIndex);
    }
}
