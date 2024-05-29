using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPathScp : MonoBehaviour
{
    public Color rayColor = Color.white;
    public List<Transform> pathObjs = new List<Transform>();

    public float küreÇap = 0.3f;

    Transform[] theArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        pathObjs.Clear();

        foreach (Transform pathObj in theArray)
        {
            if (pathObj != this.transform)
            {
                pathObjs.Add(pathObj);
            }
        }

        for (int i = 0; i < pathObjs.Count; i++)
        {
            Vector3 pos = pathObjs[i].position;

            if(i > 0)
            {
                Vector3 prev = pathObjs[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, küreÇap);
            }
        }
    }

}
