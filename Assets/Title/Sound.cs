using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Awake()
    {
        int numMusic = FindObjectsOfType<Sound>().Length;
        if (numMusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "GameScene2" || SceneManager.GetActiveScene().name == "GameScene3" || SceneManager.GetActiveScene().name == "GameScene4")
        {
            Destroy(gameObject);
        }
    }
}
