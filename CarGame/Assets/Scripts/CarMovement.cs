using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMovement : MonoBehaviour
{
    [Header("Speed")]
    public float desiredSpeed;
    public float baseAccelaration;
    public float movementSpeed;
    public float maxForwardSpeed = 8f;
    public float maxReverseSpped = 4f;
    public float TurnAccelaration = 100f;

    [Header("Turn")]
    public float baseToTurnAccelaration = 100f;
    public float baseToTurnTolerance = 0.1f;
    public float maxTurnPower = 3f;

    [Header("brake")]
    [Tooltip("Multiplier applied to current drag.")]
    public float brakePower = 2f;

    [System.NonSerialized] public Vector2 movementInput;
    [System.NonSerialized] public float forwardSpeed;
    [System.NonSerialized] public float desieredForwardSpeed;


    [System.NonSerialized] public float turnSpeed;
    [System.NonSerialized] public float desiredTurnSpeed;

    private Rigidbody2D body;
    private float initialDrag = 0f;

    public bool IsBRaking
    {
        get;
        set;
    }
        =false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        initialDrag = body.drag;
    }

    private void FixedUpdate()
    {
        if(movementInput.sqrMagnitude > 1f)
        {
            movementInput.Normalize();
            if(IsBRaking)
            {
                body.drag = Mathf.Lerp(body.drag, body.drag * brakePower, Time.fixedDeltaTime);
            }
            else
            {
                body.drag = initialDrag;

                Move();
            }
        }
    }

    private void Move()
    {
        desiredSpeed = movementInput.y *
            (movementInput.y > 0f ? maxForwardSpeed : maxReverseSpped);
            movementSpeed = Mathf.MoveTowards(movementSpeed, desiredSpeed, baseAccelaration * Time.fixedDeltaTime);
        body.AddForce(transform.right * movementSpeed);

    }

    //Todo: Turn
}
