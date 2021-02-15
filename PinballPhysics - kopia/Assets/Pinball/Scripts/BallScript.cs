using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField]
    Vector3 Velocity = Vector3.zero;
    //public Vector3 Velocity
    //{
    //    get => velocity;
    //    set => velocity = new Vector3(
    //        constrainMove_X ? 0f : value.x,
    //        constrainMove_Y ? 0f : value.y,
    //        constrainMove_Z ? 0f : value.z);
    //}
    public float mass = 1f;

    [SerializeField]
    bool useGravity = false;

    public bool isVerlet = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyForce(new Vector3(0f, 0f, 0f));

    }

    public void ApplyForce(Vector3 force)
    {
        Vector3 totalForce = useGravity ? force + mass * Physics.gravity : force;

        // f = m * a
        // a = f / m
        Vector3 acc = totalForce / mass;

        Integrate(acc, isVerlet);
        Debug.Log("acc");
    }
    void Integrate(Vector3 acc, bool isVerlet = false)
    {
        if (isVerlet == false) // use Euler
        {
            // v1 = v0 + a*detaTime
            Velocity = Velocity + acc * Time.fixedDeltaTime;

            // p1 = p0 + v*deltatime
            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
        }
        else // use Verlet
        {
            transform.position +=
                Velocity * Time.fixedDeltaTime +
                acc * Time.fixedDeltaTime * Time.fixedDeltaTime * 0.5f;

            Velocity += acc * Time.fixedDeltaTime * 0.5f; // ??
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Points"))
        {
            ScoreScript.scoreVal += 1;
        }

        if (col.gameObject.tag.Equals("Finish"))
        {
            ScoreScript.scoreVal = 0;

            this.transform.position = new Vector3(0.49f, 56.74f, 14.49999f);
            Debug.Log("ScoreVal");
        }

    }
}
