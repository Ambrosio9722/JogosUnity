using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }


    void Update()
    {
        rotate();
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }
}
