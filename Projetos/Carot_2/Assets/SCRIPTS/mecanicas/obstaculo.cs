using UnityEngine;

public class obstaculo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bala"))
        {
            Destroy(col.gameObject);
        }
    }



}
