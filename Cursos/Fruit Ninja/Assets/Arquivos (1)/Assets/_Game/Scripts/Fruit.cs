using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB;
    public GameObject fruitSliced;
    private GameControler gameControler;

    [SerializeField] private float startForce;

    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        gameControler = FindAnyObjectByType<GameControler>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ApplyForce()
    {
        myRB.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    public Color32 ChangeSplashColor(GameObject GO)
    {
        string cloneObjectName = GO.transform.name;
        Color32 defaultColor = new Color32(255,255,255,255);

        switch (cloneObjectName)
        {
            case "Apple(Clone)":
                return gameControler.appleColor;

            case "banana(Clone)":
                return gameControler.bananaColor;

            case "coconut(Clone)":
                return gameControler.coconutColor;

            case "melancia(Clone)":
                return gameControler.melanciaColor;

            case "morango(Clone)":
                return gameControler.morangoColor;
        }
        return defaultColor;
    }
}
