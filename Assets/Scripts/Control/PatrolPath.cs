using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            const float waypointGizmoRaidius = 0.3f;

            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                print(j);
                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRaidius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }
        
        public int GetNextIndex(int i)
        {
            return (i + 1) % transform.childCount;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
