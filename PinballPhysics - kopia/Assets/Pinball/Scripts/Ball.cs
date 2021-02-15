using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Vector3 velocity;
    [SerializeField] float force = 1;
    [SerializeField] ForceMode mode = ForceMode.Force;
 
    [SerializeField] float sphereMass;


    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        TestData();
        //ApplyForceToVelocity();
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Points"))
        {
            ScoreScript.scoreVal += 1;
        }

        if (col.gameObject.tag.Equals("Finish"))
        {
            ScoreScript.scoreVal = 0;

            this.transform.position = new Vector3(0.49f, 56.74f, 14.49999f);
        }

    }

    //public void ApplyForceToVelocity()
    //{
    // if(force == 0 || velocity.magnitude == 0)
    //    {
    //        return;
    //        velocity = velocity + velocity.normalized * 0.2f * rb.drag;

    //     //force = 1 => need 1 s to reach velocity (if mass is 1) =< force can be max 1/ Time.FixedDeltatime
    //        force = Mathf.Clamp(force, sphereMass / Time.fixedDeltaTime, sphereMass / Time.fixedDeltaTime);

    //    //    //dot product is projection from rhs to lhs with length of result / lhs.magnitude
    //        if(rb.velocity.magnitude == 00)
    //        {
    //            rb.AddForce(velocity * force, mode);
    //        }
    //        else
    //        {
    //           var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rb.velocity) / velocity.magnitude);
    //            rb.AddForce((velocity - velocityProjectedToTarget) * force, mode);

    //        Debug.Log("force");
    //        }
    //     }
    //}

    private void TestData()
    {
        //Displays the speed of the sphere in editor
        speed = rb.velocity.magnitude;
        //Displays the angularVelocity of the sphere in editor
        //angularSpeed = rb.angularVelocity.magnitude;

    }
}
