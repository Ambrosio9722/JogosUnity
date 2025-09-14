using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    private bool faceflip;
    
    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        //  Mover();
        transform.Translate(Vector2.left* velocidade*Time.deltaTime);
    }

   // private void Mover()
   // {
  //      rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
  //  }

 //   private void OnTriggerExit2D(Collider2D collision)
 //   {
 //       velocidade *= -1;
 //       Flip();
 //   }

 //   private void Flip()
 //   {
 //       Vector3 currentScale = gameObject.transform.localScale;
 //       currentScale.x *= -1;
 //       gameObject.transform.localScale = currentScale;
 //   }

 // void OnTriggerEnter2D(Collider2D col)
 //   {
 //       if (col.gameObject.CompareTag("bala")) // bala
 //       {
 //           Destroy(col.gameObject); // destroi bala
//            Destroy(this.gameObject);
//        }
//    }

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

