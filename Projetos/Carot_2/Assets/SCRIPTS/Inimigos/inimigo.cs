using Unity.VisualScripting;

using UnityEngine;

public class inimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    private bool faceflip;
    
    void Start()
    {
      
    }

   
    void Update()
    {
      
        transform.Translate(Vector2.left* velocidade*Time.deltaTime);
    }

 

    private void FlipEnemy()
    {
        if (faceflip)
        {
             gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("player") && !col.collider.CompareTag("chao"))
        {
            faceflip = !faceflip;
        }
        FlipEnemy();
    }
}

