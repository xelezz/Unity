using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class WaypointType : ScriptableObject
{
    [Tooltip("Change the color")]
    public Color col = Color.red;

    [Tooltip("Add waypoints")]
    public Vector3[] wayPoints;

    [Tooltip("Start waypoint")]
    public int startPoint = 0;

    [Tooltip("The speed of the object moving between waypoints")]
    public float speed;

    [Tooltip("Randomizes movement between waypoints")]
    public bool random;
    
    [Tooltip("Enable/Disable waypoint system")]
    public bool Enable = true;

    [HideInInspector]
    public float distance = 1f;
    [HideInInspector]
    public MaterialPropertyBlock mpb;
}
