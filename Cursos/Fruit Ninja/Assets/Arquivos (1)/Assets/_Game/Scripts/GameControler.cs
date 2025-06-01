using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splash;

    [HideInInspector] public Color32 appleColor = new Color32(121,148,12,255), coconutColor = new Color32(112,71,44, 255), morangoColor = new Color32(167,0,20, 255), bananaColor = new Color32(238,195,27,255), melanciaColor = new Color32(72,108,13, 255), uiRedColor = new Color32(255,0,0,255), uiWhiteColor = new Color32(255,255,255,255);
    private UIControler uiController;

    [HideInInspector] public int score, fruitCount;

    [SerializeField] private GameObject fruitSpawner, blade, destrower;

    private int highscore;
    private GameData gameData;

    public Transform allObjects, allSplasher, allSlicedFruits;
    void Start()
    {
        uiController = FindAnyObjectByType<UIControler>();
        gameData = FindAnyObjectByType<GameData>();
        highscore = gameData.GetScore();
        score = 0;
        fruitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        uiController.txtHighscore.text = " Score: " + score.ToString();
     }
    public void UpdateScore(int points)
    {
        score += points;
        uiController.txtScore.text = "Score: " + score.ToString();
    }
    public void GameOver()
    {
        fruitSpawner.gameObject.SetActive(false);
        destrower.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        if (score > highscore)
        {
            gameData.SaveScore(score);
        }
    }
    public void RestarteGame()
    {
          score = 0;
           fruitCount = 0;
         uiController.txtScore.text = "Score: " + score.ToString();
        fruitSpawner.gameObject.SetActive(true);
        destrower.gameObject.SetActive(true);
        blade.gameObject.SetActive(true);
    }
}


