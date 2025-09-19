using UnityEngine;
using UnityEngine.UI;

public class balasUI : MonoBehaviour
{
    // UI de balas
    public Image[] ImagensBalas;
    private player Player;
    int balas;
  

    // abrir primeira tampa
   public static bool tampaAberta;
    public GameObject tampa01;
    void Start()
    {
        Player = FindAnyObjectByType<player>();
        tampaAberta = false;
    }

  
    void Update()
    {
          balas = player.Quantasbalas;
           ImagensBalas[balas].gameObject.SetActive(false);

        if (tampaAberta == true)
        {
            tampa01.transform.rotation = Quaternion.Euler(0,0,-90);
        }
    }

    public void encherBalas()
    {
        for (int i = 0; i<5; i++)
        {
            ImagensBalas[i].gameObject.SetActive(true);
        }
    }
}
