using UnityEngine;

public class raiosSol : MonoBehaviour
{
    public float velocidadeRaio;

    void Start()
    {
        
    }

    
    void Update()
    {
        //rodar um objeto
        gameObject.transform.Rotate(new Vector3(0,0,velocidadeRaio));
    }
}
