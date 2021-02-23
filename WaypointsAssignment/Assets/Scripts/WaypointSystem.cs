using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public WaypointType type;
    static readonly int shPropColor = Shader.PropertyToID("_Color");


    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position,(type.wayPoints[type.startPoint]));
        if (type.Enable)
        {
            if (dist > type.distance)
            {
                Move();
            }
            else
            {
                if (!type.random)
                {
                    if (type.startPoint + 1 == type.wayPoints.Length)
                    {
                        type.startPoint = 0;
                    }
                    else
                    {
                        type.startPoint++;
                    }
                }
                else
                {
                    type.startPoint = Random.Range(0, type.wayPoints.Length);
                }
            }
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
    

    public void Move()
    {
        gameObject.transform.LookAt(type.wayPoints[type.startPoint],transform.position);
        gameObject.transform.position += gameObject.transform.forward * type.speed * Time.deltaTime;
    }
    public MaterialPropertyBlock Mpb
    {
        get
        {
            if (type.mpb == null)
                type.mpb = new MaterialPropertyBlock();
            
            return type.mpb;
        }
    }

    // caleld on property change
    void OnValidate()
    {
        ApplyColor();
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        ApplyColor();
        if (type.mpb == null)
            type.mpb = new MaterialPropertyBlock();
        WaypointManager.allWaypoints.Add(this);
    }

    void ApplyColor()
    {
        if (type == null)
            return;
        MeshRenderer rnd = GetComponent<MeshRenderer>();
        Mpb.SetColor(shPropColor, type.col);

        rnd.SetPropertyBlock(Mpb);
    }
    [ExecuteAlways]
    private void OnDisable()
    {
        Debug.Log("OnDisable");
        WaypointManager.allWaypoints.Remove(this);
    }
}
