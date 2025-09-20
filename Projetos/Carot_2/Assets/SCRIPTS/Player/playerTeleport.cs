using UnityEngine;

public class playerTeleport : MonoBehaviour
{
  
    public GameObject portal;
    private GameObject player;
    public int DireitaEsquerda;  // -1 1
    void Start()
    {
        
        player = GameObject.FindWithTag("player");
    }

   
    void Update()
    {
 
    }

  private void OnTriggerEnter2D(Collider2D col)
   {
       

        if (col.tag == "player")
        {
            player.transform.position = new Vector2(portal.transform.position.x+DireitaEsquerda,portal.transform.position.y);
        }
   }

}
