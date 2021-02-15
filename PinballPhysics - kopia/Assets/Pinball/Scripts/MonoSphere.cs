
using UnityEngine;

public class MonoSphere : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private Vector3 vel;

    private Rigidbody rb;
    [SerializeField]
    bool useGravity = false;

    public bool isVerlet = true;
    public float mass = 1f;

    private void Start()
    {
        //mode = ForceMode.Force;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        TestData();
        //ApplyForceToReachVelocity(rb, Vector3.down* 10,1000);
        ApplyForce(new Vector3(0f, 0f, 0f));

    }
    private void FixedUpdate()
    {
      // rb.AddForce(Vector3.down);

    }
    public void ApplyForce(Vector3 force)
    {
        Vector3 totalForce = useGravity ? force + mass * Physics.gravity : force;

        // f = m * a
        // a = f / m
        Vector3 acc = totalForce / mass;

        Integrate(acc, isVerlet);
    }
    void Integrate(Vector3 acc, bool isVerlet = false)
    {
        if (isVerlet == false) // use Euler
        {
            // v1 = v0 + a*detaTime
            vel = vel + acc * Time.fixedDeltaTime;

            // p1 = p0 + v*deltatime
            transform.position = transform.position + vel * Time.fixedDeltaTime;
        }
        else // use Verlet
        {
            transform.position +=
                vel * Time.fixedDeltaTime +
                acc * Time.fixedDeltaTime * Time.fixedDeltaTime * 0.5f;

            vel += acc * Time.fixedDeltaTime * 0.5f; // ??
        }
    }

    public void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velo, float force = 1, ForceMode mode = ForceMode.Force)
    {
        if(force == 0 || velo.magnitude == 0)
        
            return;

            velo = velo + velo.normalized * 0.2f * rigidbody.drag;
            force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);
            if(rigidbody.velocity.magnitude ==0)
            {
                rigidbody.AddForce(velo * force, mode);
            }
            else
            {
                var velProjectedToTarget = (velo.normalized * Vector3.Dot(velo, rigidbody.velocity) / velo.magnitude);
                rb.AddForce((velo - velProjectedToTarget) * force, mode);
            Debug.Log(force);
            }
      }
    
    private void OnCollisionEnter(Collision col)
    {

        //Adds 1 point to your score when colliding with an game object that has the tag points
        if (col.gameObject.tag.Equals("Points"))
        {
            ScoreScript.scoreVal += 1;
        }

        //Resets the score value when colliding with the finish game object and resets the position of the sphere
        if (col.gameObject.tag.Equals("Finish"))
        {
            ScoreScript.scoreVal = 0;

            this.transform.position = new Vector3(0.49f, 56.74f, 14.49999f);
        }

    }
    private void TestData()
    {
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;
    }
   

}
