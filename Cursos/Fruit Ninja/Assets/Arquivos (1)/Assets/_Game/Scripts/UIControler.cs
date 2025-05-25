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

    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameControler = FindAnyObjectByType<GameControler>();
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
    }
    public IEnumerator ShowBombPanelGameover()
    {
        gameControler.GameOver();
        panelGame.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        panelGameover.gameObject.SetActive(true);
    }

    public void ShowPanelGameover()
    {   
        panelGameover.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        gameControler.GameOver();

    }
}
