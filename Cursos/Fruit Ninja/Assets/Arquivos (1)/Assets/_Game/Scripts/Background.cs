using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Start()
    {
        // passando o "SpriteRenderer" para a variavel --SpriteRenmderer-- (buscando dentro dos objetos filho)
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale;

        //pegar a largura em x(horizontal)
        float width = sprite.bounds.size.x;
        //pegar a altura em y(vertical)
        float height = sprite.bounds.size.y;
        // valor ortografico da camera 
        float heightCAmera = Camera.main.orthographicSize * 2.0f;
        // Scream = tela
        float widthworld = heightCAmera / Screen.height * Screen.width;

        scaleTemp.x = widthworld / width;
        scaleTemp.y = heightCAmera / height;

        transform.localScale = scaleTemp;

    }


}