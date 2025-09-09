using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class vidaPlayer : MonoBehaviour
{
    public UnityEngine.UI.Image imagemVida;
    public float valorVida = 1f;
    void Start()
    {
        
    }

  
    void Update()
    {
        imagemVida.fillAmount = valorVida;
    }
}
