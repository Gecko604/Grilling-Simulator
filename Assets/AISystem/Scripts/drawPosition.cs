using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        // Must have Tag
        if (gameObject.tag == "Untagged") { return; }

        // Draw a colored sphere at the transform's position
        Gizmos.color = drawColor(gameObject.tag);
        Gizmos.DrawSphere(transform.position, 0.25f);
    }

    private Color drawColor(string tag)
    {
        if (tag == "LinePos") { return Color.black; }
        if (tag == "WaitPos") { return Color.blue; }
        if (tag == "SeatPos") { return Color.yellow; }
        if (tag == "BossPos") { return Color.red; }
        if (tag == "ExitPos") { return Color.green; }

        // default case
        return Color.white;
    }

}
