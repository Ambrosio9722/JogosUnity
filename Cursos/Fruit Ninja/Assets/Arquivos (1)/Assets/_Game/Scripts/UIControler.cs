using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TMP_Text txtScore, txtHighscore, txtHighscoreGameOver, txtHighscoreMainMenu;

    public Image[] imgLivbes;

    public Button BtnPause, btnResume, btnMainMenu, btnClosePauseMenu, btnSounds, btnSoundsMainMenu;

    public GameObject panelGame, panelPause, panelGameover, panelMainMenu;

    private GameControler gameControler;

    private GameData gameData;

    public Sprite soundOn, soundOff;

    private audioControler AudioControler;

    void Start()
    {
        panelMainMenu.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        gameControler = FindAnyObjectByType<GameControler>();
        gameData = FindAnyObjectByType<GameData>();
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
        txtHighscoreMainMenu.text = "Highscore: " + gameData.GetScore().ToString();
        AudioControler = FindAnyObjectByType<audioControler>();
    }

   
    void Update()
    {
        
    }
    public void ButtonPauseGame()
    {
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ButtonClosePanelPause()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameControler.SoundsData();
    }
    public void ShowBombPanelGameover()
    {
        gameControler.GameOver();
        panelGame.gameObject.SetActive(false);
       
        panelGameover.gameObject.SetActive(true);
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
        txtHighscoreGameOver.text = "Highscore: " + gameData.GetScore().ToString();
    }

    public void ShowPanelGameover()
    {   
        panelGameover.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        gameControler.GameOver();
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
        txtHighscoreGameOver.text = "Highscore: " + gameData.GetScore().ToString();
    }
    public void ButtonRestartGame()
    {
        panelGame.gameObject.SetActive(true);
        panelGameover.gameObject.SetActive(false);
        gameControler.RestarteGame();
        txtScore.text = "Score: " + gameControler.score.ToString();
        for (int i = 0; i < imgLivbes.Length; i++)
        {
            imgLivbes[i].color = gameControler.uiWhiteColor;
        }
    }

    public void ButtonSounds()
    {
        if (gameControler.soundOnOff)
        {
            gameControler.soundOnOff = false;
            btnSounds.gameObject.GetComponent<Image>().sprite = soundOff;
            btnSoundsMainMenu.gameObject.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            gameControler.soundOnOff = true;
            btnSounds.gameObject.GetComponent<Image>().sprite = soundOn;
            btnSoundsMainMenu.gameObject.GetComponent<Image>().sprite = soundOn;
        }
        AudioControler.EnableAndDisableAudio();
    }
  public void ButtonBackMainMenu()
    {
        panelMainMenu.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        gameControler.BackMainMenu();
        txtHighscoreMainMenu.text = "Highscore: " + gameData.GetScore().ToString();
        for (int i = 0; i < imgLivbes.Length; i++)
        {
            imgLivbes[i].color = gameControler.uiWhiteColor;
        }
    }
    public void ButtonStartGame()
    {
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameControler.StartGame();
        txtScore.text = "Score: " + gameControler.score.ToString();
    }

    public void ButtonExitGame()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

}

