using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TMP_Text tctScore, txtHighscore;

    public Image[] imgLivbes;

    public Button BtnPause, btnResume, btnMainMenu, btnClosePauseMenu, btnSounds;

    public GameObject panelGame, panelPause;



    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
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
}
