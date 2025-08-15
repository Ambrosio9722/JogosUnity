using UnityEngine;
using UnityEngine.SceneManagement;

public class trocaDeCenas : MonoBehaviour
{


   public  void Menu()
    {
        SceneManager.LoadScene("Menu");

    }

   public  void Fases()
    {
        SceneManager.LoadScene("Fases");
    }

    public void Mecanicas()
    {
        SceneManager.LoadScene("Mecanicas");
    }
}
