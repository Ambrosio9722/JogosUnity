using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameControler gameController;
    private UIControler uiController;
    private audioControler audioControler;
       
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindAnyObjectByType<GameControler>();
        uiController = FindAnyObjectByType<UIControler>();
        audioControler = FindAnyObjectByType<audioControler>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Blade"))
        {
            target.gameObject.GetComponent<AudioSource>().clip = audioControler.bladeAudio[Random.Range(0, audioControler.bladeAudio.Length)];
            target.gameObject.GetComponent<AudioSource>().Play();
            GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position,Quaternion.identity);
            tempFruitSliced.transform.parent = gameController.allSlicedFruits;
            tempFruitSliced.gameObject.GetComponent<AudioSource>().clip = audioControler.fruitSplashAudio[Random.Range(0, audioControler.fruitSplashAudio.Length)];
            tempFruitSliced.gameObject.GetComponent<AudioSource>().Play();
            GameObject tempSplash = Instantiate(gameController.splash, new Vector3 (tempFruitSliced.transform.position.x, tempFruitSliced.transform.position.y,10f), Quaternion.identity);
            tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject);
            tempSplash.transform.parent = gameController.allSplasher;
            gameController.UpdateScore(this.gameObject.GetComponent<Fruit>().points);
            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f, 10f), ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f, 10f), ForceMode.Impulse);
            Destroy(tempFruitSliced, 5f);
            Destroy(tempSplash, 3f);
            Destroy(this.gameObject);
        }
        if (target.gameObject.CompareTag("Destroyer"))
        {
            gameController.fruitCount++;
            uiController.imgLivbes[gameController.fruitCount - 1].color = gameController.uiRedColor;
            if (gameController.fruitCount >= 3)
            {
                uiController.ShowPanelGameover();
            }
        }
    }
}
