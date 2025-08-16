using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D corpo;
    public float velocidade;
    private SpriteRenderer sprit;
    public float pulo;

    // conferir o chao
    public Transform conferirChao;
    public LayerMask layerDoChao;

    void Start()
    {
        corpo = GetComponent<Rigidbody2D>(); // pegar um componente na unity
        sprit = GetComponent<SpriteRenderer>(); // virar o player 
    }

 
    void Update()
    {
        //andar
        float horizontal = Input.GetAxis("Horizontal");
        corpo.linearVelocity = new Vector2(horizontal*velocidade, corpo.linearVelocity.y);

        // virar sprit
        flip(horizontal);
        jump();
    }

    // função rodar personagem
    private void flip(float horizontal)
    {
        if (horizontal > 0)
        {
            sprit.flipX = false;
        }
        else if (horizontal < 0)
        {
            sprit.flipX = true;
        }

    }

    // função de pulo 
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estouNoChao())
        {
        corpo.AddForce(new Vector2(0, pulo)); 
        }
    }


    public bool estouNoChao()
    {

        if (corpo.linearVelocity.y <= 0 )
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(conferirChao.position, 0.5f,layerDoChao);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    return true;
                }
            }


        }

        return false;
    }
}
