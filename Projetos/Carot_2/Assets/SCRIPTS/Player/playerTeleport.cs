using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    private GameObject currentTeleport;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTeleport != null)
        {
            transform.position = currentTeleport.GetComponent<Teleport>().GetDestination().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("teleporte"))
        {
            currentTeleport = col.gameObject;
        }
    }
}
