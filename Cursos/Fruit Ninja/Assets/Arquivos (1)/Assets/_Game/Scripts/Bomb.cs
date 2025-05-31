using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed, startForce;

    [SerializeField] private GameObject beamLight;

    private Rigidbody2D myRB;

    private audioControler audioControler;

    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        ApplyForce();
        audioControler = FindAnyObjectByType<audioControler>();
    }


    void Update()
    {
        rotate();
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }

    private void ApplyForce()
    {
        myRB.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    public void BombGameOver()
    {
        speed = 0f;
       
        myRB.bodyType = RigidbodyType2D.Kinematic;
        myRB.simulated = false;
        CircleCollider2D myCollider = this.gameObject.GetComponent<CircleCollider2D>();
        myCollider.enabled = false;
        GameObject tempBeamLight = Instantiate(beamLight, this.transform.position, Quaternion.identity) as GameObject;
        this.gameObject.GetComponent<AudioSource>().clip = audioControler.bombExplodeAudio;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
