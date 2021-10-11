using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public HingeJoint lever;
    public float leverAngle;
    public float leverValue;
    public float speed;
    public float maxSpeed;

    void Start()
    {
        lever = GetComponent<HingeJoint>();
        
    }

    void Update()
    {
        leverAngle = lever.angle - lever.limits.min;
        leverValue = leverAngle / (lever.limits.max - lever.limits.min);
        speed = leverValue * maxSpeed;
    }
}
