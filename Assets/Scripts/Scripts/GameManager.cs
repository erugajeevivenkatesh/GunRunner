using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameoverPanel;
    void Start()
    {
        gameoverPanel.SetActive(false);
        
    }

  
    public void ReloadGame()
    {
        SceneManager.LoadScene(0); 
    }
    public void loadGameOver()
    {
        gameoverPanel.SetActive(true);

    }
}
