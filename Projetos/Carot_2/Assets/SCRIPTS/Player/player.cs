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

    // tiro
    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaDoTiro;
    private bool flipX = false;

    // animação tiro

    public Animator animator;
    public bool atirou = false;
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>(); // pegar um componente na unity
        sprit = GetComponent<SpriteRenderer>(); // virar o player 
        animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        //andar
        float horizontal = Input.GetAxis("Horizontal");
        corpo.linearVelocity = new Vector2(horizontal*velocidade, corpo.linearVelocity.y);

        // virar sprit
        flip(horizontal);
        jump();

        //tiro
        tiro = Input.GetButtonDown("Fire1");
        Atirar();

        
    }

    // função rodar personagem
    private void flip(float horizontal)
    {
        if (horizontal > 0 && flipX== true)
        {
            Flipx();
           // sprit.flipX = false;
        }
        else if (horizontal < 0 && flipX == false)
        {
            Flipx();
          //  sprit.flipX = true;
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

    // função atirar
    private void Atirar()
    {
        if (tiro == true)
        {
            atirou = true;
            animator.SetBool("tiro", true);
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(forcaDoTiro,0);
            Destroy(temp.gameObject, 3f);
        }
       else if (tiro == false)
        {
            animator.SetBool("tiro", false);
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

    private void Flipx()
    {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        forcaDoTiro *= -1;
    }
}
