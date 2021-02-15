using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float restPosition = 0f;
    [SerializeField] private float pressedPosition = 45f;
    [SerializeField] private float hitStrenght = 10000;
    [SerializeField] private float flipperDamper = 150f;
    [SerializeField] private string inputName;
    HingeJoint hinge;
    public float ballPush = 5f;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    private void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        if(Input.GetAxis(inputName)== 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
