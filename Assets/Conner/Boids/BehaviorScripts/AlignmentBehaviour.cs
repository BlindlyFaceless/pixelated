using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector3 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours maintain heading
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        //add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentMove += item.transform.forward;
        }
        alignmentMove /= context.Count;

        // create offset from agent pos
        return alignmentMove;
    }
}
