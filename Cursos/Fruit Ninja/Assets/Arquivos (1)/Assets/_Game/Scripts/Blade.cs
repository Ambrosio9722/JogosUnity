 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private CircleCollider2D circleCollider;
    private Vector2 previousPosition;
    [SerializeField] private float minCuttingVelocity = 0.001f;

    private void Awake()
    {
        trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
        circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        trailRenderer.enabled = false;
        circleCollider.enabled = false;
    }

   
    void Update()
    {
        
    }
}
