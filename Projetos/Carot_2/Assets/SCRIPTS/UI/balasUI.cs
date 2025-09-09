using UnityEngine;
using UnityEngine.UI;

public class balasUI : MonoBehaviour
{
    public Image[] ImagensBalas;
    private player Player;
    int balas;
  
    void Start()
    {
        Player = FindAnyObjectByType<player>();
    }

  
    void Update()
    {
       balas = player.Quantasbalas;


        ImagensBalas[balas].gameObject.SetActive(false);
    }

    public void encherBalas()
    {
        for (int i = 0; i<5; i++)
        {
            ImagensBalas[i].gameObject.SetActive(true);
        }
    }
}
