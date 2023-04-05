using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Dictionary<int, GameObject> unitTable = new Dictionary<int, GameObject>();

    public int charCount;
    
    // Start is called before the first frame update
    void Awake()
    {
        charCount = unitTable.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
