using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    public int hp;

    public List<string> levels;


    public static GameManager instance;

    

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }


    public void Win()
    {
        currentLevel++;
        Invoke("LoadScene", 1f);
        SceneManager.LoadScene(levels[currentLevel]);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levels[currentLevel]);
    }


    public void Lose()
    {
        hp--;
        if (hp > 0)
        {
            Invoke("LoadScene", 1f);
        }
        else
        {
            currentLevel = 0;
            Invoke("LoadScene", 1f);
        }
    }
}
