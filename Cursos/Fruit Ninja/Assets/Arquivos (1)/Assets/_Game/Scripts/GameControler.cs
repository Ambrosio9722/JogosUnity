using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splash;

    [HideInInspector] public Color32 appleColor = new Color32(121,148,12,255), coconutColor = new Color32(112,71,44, 255), morangoColor = new Color32(167,0,20, 255), bananaColor = new Color32(238,195,27,255), melanciaColor = new Color32(72,108,13, 255);
    private UIControler uiController;

    [HideInInspector] public int score;
    void Start()
    {
        uiController = FindAnyObjectByType<UIControler>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        uiController.txtHighscore.text = " Score: " + score;
     }

}


