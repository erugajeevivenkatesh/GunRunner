using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Uimanager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public float Score;
    public GameObject _Player;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

  
    void Update()
    {

        Score=_Player.transform.position.z;
        int x =(int) Score;
        scoreText.text=x.ToString();
        
    }
}
