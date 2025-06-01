using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollider : MonoBehaviour
{
    private Bomb bomb;
    private UIControler uiControler;
    private void Start()
    {
        bomb = this.gameObject.GetComponent<Bomb>();
        uiControler = FindAnyObjectByType<UIControler>();
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Blade"))
        {
            bomb.BombGameOver();
         uiControler.ShowBombPanelGameover();
        }
    }
}
