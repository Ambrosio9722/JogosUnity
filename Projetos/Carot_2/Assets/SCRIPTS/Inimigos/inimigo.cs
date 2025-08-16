using UnityEditor.Tilemaps;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        velocidade *= -1;
        Flip();
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
