using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WaypointManager : MonoBehaviour
{
    public static List<WaypointSystem> allWaypoints = new List<WaypointSystem>();
    #if UNITY_EDITOR //Makes it dissapear in build 
    private void OnDrawGizmos()
    {
        foreach(WaypointSystem waypoint in allWaypoints )
        {
            if (waypoint.type == null)
                continue;
            Vector3 managerPos = transform.position;
            Vector3 WaypointPos = waypoint.transform.position;
            float halfhight = (managerPos.y - WaypointPos.y) * .5f;
            Vector3 offset = Vector3.up * halfhight;

            //Creates the lines between the objects and the manager
            Handles.DrawBezier(managerPos, WaypointPos, managerPos - offset, WaypointPos + offset, Color.white, EditorGUIUtility.whiteTexture, 1f);     
        }

    }
    #endif
}
