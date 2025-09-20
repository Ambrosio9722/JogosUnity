using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    //  private GameObject currentTeleport;
    //  public bool podeTP;
    //  float tempo = 0;
    public GameObject portal;
    private GameObject player;
    void Start()
    {
        //      podeTP = true;
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
  //      if (currentTeleport != null)
  //      {
  //          transform.position = currentTeleport.GetComponent<Teleport>().GetDestination().position;
  //      }
    }

  private void OnTriggerEnter2D(Collider2D col)
   {
        //      if (col.CompareTag("teleporte") && podeTP == true) 
        //      {
        //           currentTeleport = col.gameObject;
        //          podeTP = false;
        //          tempoTP();
        //      }

        if (col.tag == "player")
        {
            player.transform.position = new Vector2(portal.transform.position.x+1,portal.transform.position.y);
        }
   }

  //  private void tempoTP()
  //  {
  //      tempo += Time.deltaTime;

  //      if (tempo >= 2f)
  //      {

  //          podeTP = true;
  //              tempo = 0;
  //       
  //      }
 //   }
}
