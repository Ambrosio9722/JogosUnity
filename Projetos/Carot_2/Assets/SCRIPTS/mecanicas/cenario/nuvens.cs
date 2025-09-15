using UnityEngine;

public class nuvens : MonoBehaviour
{
    public SliderJoint2D slider;
    public JointMotor2D motor;
    public float velocidade;
    private SpriteRenderer flip;
    void Start()
    {
        motor = slider.motor;
        flip = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            motor.motorSpeed = velocidade;
            slider.motor = motor;
            flip.flipX =false;
            
        }
        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            motor.motorSpeed = -velocidade;
            slider.motor = motor;
            flip.flipX = true;
        }
    }
}
