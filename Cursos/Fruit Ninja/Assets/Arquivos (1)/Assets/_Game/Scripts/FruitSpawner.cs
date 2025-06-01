using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay, maxDelay;
    private GameControler gameControler;
    [HideInInspector] public Coroutine splashCorrotine;
  
    private void Awake()
    {
        gameControler = FindAnyObjectByType<GameControler>();
    }

    // Update is called once per frame
    public IEnumerator Spawn()
    {
        while (gameControler.gameStart)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject fruitPrefab = Instantiate(fruitsPrefab[Random.Range(0, fruitsPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
            fruitPrefab.transform.parent = gameControler.allObjects;
            Destroy(fruitPrefab, 5f);
        }
    }
}
