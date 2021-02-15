using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{ 
 [SerializeField] private float speed;
[SerializeField] private float angularSpeed;
[SerializeField] private Vector3 vel;
private Rigidbody rb;
//[SerializeField] private Vector3 force;
[SerializeField] private Vector3 acc;
[SerializeField] private float mass = 1;
[SerializeField] private float dragAmounth = 1f;
bool useGravity = false;
[SerializeField] private float sphereSpeed = 0;


//this is our target velocity while decelerating
private float initialVelocity = 0.0f;

//this is our target velocity while accelerating
private float finalVelocity = 500.0f;

//this is our current velocity
private float currentVelocity = 0.0f;

//this is the velocity we add each second while accelerating
[SerializeField] private float accelerationRate = 10.0f;

//this is the velocity we subtract each second while decelerating
[SerializeField] private float decelerationRate = 50.0f;


void Start()
{
    rb = GetComponent<Rigidbody>();
}

void Update()
{

    //ApplyForce(new Vector3(0f, 0f, 0f));
    //ApplyDrag();
    TestData();
}
private void OnCollisionEnter(Collision col)
{
    if (col.gameObject.tag.Equals("Wall"))
    {
        //add to the current velocity according while accelerating
        currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
    }
    else
    {
        //subtract from the current velocity while decelerating
        currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
    }

    //ensure the velocity never goes out of the initial/final boundaries
    currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

    //propel the object forward


    if (col.gameObject.tag.Equals("Points"))
    {
        ScoreScript.scoreVal += 1;
    }

    if (col.gameObject.tag.Equals("Finish"))
    {
        ScoreScript.scoreVal = 0;

        this.transform.position = new Vector3(0.49f, 56.74f, 14.49999f);
    }

}
void ApplyForce()
{

}
//protected void ApplyDrag()
//{
//    Vector3 dragForce = -dragAmounth * vel;
//    ApplyForce(dragForce);

//}
//public void ApplyForce(Vector3 force)
//{
//    vel = useGravity ? force + mass * Physics.gravity * Time.deltaTime : force;
//    acc = vel * mass;
//    force = vel + acc * Time.deltaTime;
//    transform.position = transform.position + sphereSpeed * acc * Time.deltaTime;
//    Debug.Log(sphereSpeed);
//}
private void TestData()
{
    speed = rb.velocity.magnitude;
    angularSpeed = rb.angularVelocity.magnitude;
}
}