using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FactionSelect : MonoBehaviour
{
    public static FactionSelect Instance;
    public string dataSelection;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void BloodRavenSelect()
    {
        dataSelection = "Blood Ravens";
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadChapterOrg()
    {
        SceneManager.LoadScene(2);
    }
}
