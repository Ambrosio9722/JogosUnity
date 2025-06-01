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

    public Transform allObjects, allSplasher, allSlicedFruits,allLightBeams;

    [HideInInspector] public bool soundOnOff, gameStart;

    private FruitSpawner fruitSpawnerScript;
    void Start()
    {
        soundOnOff = true;
        gameStart = false;
        uiController = FindAnyObjectByType<UIControler>();
        fruitSpawnerScript = FindAnyObjectByType<FruitSpawner>();
        gameData = FindAnyObjectByType<GameData>();
        highscore = gameData.GetScore();
        score = 0;
        fruitCount = 0;
        Inicialize();
        SoundsData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Inicialize()
    {
        int soundValue = gameData.GetSounds();
        if (soundValue == 1)
        {
            soundOnOff = true;
            uiController.btnSounds.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uiController.soundOn;
            uiController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uiController.soundOn;
        }
        else
        {
            soundOnOff = false;
            uiController.btnSounds.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uiController.soundOff;
            uiController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uiController.soundOff;
        }
    }

    public void StartGame()
    {
        RestarteGame();
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
        gameStart = false;
        StopCoroutine(fruitSpawnerScript.splashCorrotine);
        if (score > highscore)
        {
            gameData.SaveScore(score);
        }
    }
    public void RestarteGame()
    {
          score = 0;
           fruitCount = 0;
        
        fruitSpawner.gameObject.SetActive(true);
        destrower.gameObject.SetActive(true);
        blade.gameObject.SetActive(true);
        gameStart = true;
        fruitSpawnerScript = FindAnyObjectByType<FruitSpawner>();
        fruitSpawnerScript.splashCorrotine = StartCoroutine(fruitSpawnerScript.Spawn());
        foreach (Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }
    }

    public void SoundsData()
    {
        if (soundOnOff)
        {
            gameData.Savesounds(1);
            soundOnOff = true;
        }
        else
        
            {
                gameData.Savesounds(0);
            soundOnOff = false;
            }
    }
    public void BackMainMenu()
    {
        score = 0;
        fruitCount = 0;
        fruitSpawner.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        destrower.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameStart = false;
        StopCoroutine(fruitSpawnerScript.splashCorrotine);

        foreach (Transform child in allObjects)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allSlicedFruits)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allSplasher)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }
    }

}


