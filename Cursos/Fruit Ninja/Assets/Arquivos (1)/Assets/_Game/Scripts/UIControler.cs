using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TMP_Text txtScore, txtHighscore;

    public Image[] imgLivbes;

    public Button BtnPause, btnResume, btnMainMenu, btnClosePauseMenu, btnSounds;

    public GameObject panelGame, panelPause, panelGameover;

    private GameControler gameControler;

    private GameData gameData;

    public Sprite soundOn, soundOff;

    private audioControler AudioControler;

    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameControler = FindAnyObjectByType<GameControler>();
        gameData = FindAnyObjectByType<GameData>();
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
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
    public IEnumerator ShowBombPanelGameover()
    {
        gameControler.GameOver();
        panelGame.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        panelGameover.gameObject.SetActive(true);
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
    }

    public void ShowPanelGameover()
    {   
        panelGameover.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        gameControler.GameOver();
        txtHighscore.text = "Highscore: " + gameData.GetScore().ToString();
    }
    public void ButtonRestartGame()
    {
        panelGame.gameObject.SetActive(true);
        panelGameover.gameObject.SetActive(false);

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
        }
        else
        {
            gameControler.soundOnOff = true;
            btnSounds.gameObject.GetComponent<Image>().sprite = soundOn;
        }
        AudioControler.EnableAndDisableAudio();
    }
  

}

