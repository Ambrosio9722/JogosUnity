using UnityEngine;

public class controle_porta_1 : MonoBehaviour
{
    private bool podeAbrir;
    void Start()
    {
        podeAbrir = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (podeAbrir == true)
        {
          if (Input.GetKeyDown(KeyCode.E))
            {
                balasUI.tampaAberta = true;
            }
        }
        else
        {
           if (Input.GetKeyDown(KeyCode.E))
            {
                balasUI.tampaAberta = false;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            podeAbrir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            podeAbrir = false;
        }
    }
}
