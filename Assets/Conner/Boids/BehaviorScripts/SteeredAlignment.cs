using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Alignment")]
public class SteeredAlignment : FilteredFlockBeahviour
{
    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;
    public override Vector3 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours maintain heading
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        //add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += item.transform.forward;
        }
        alignmentMove /= context.Count;

        // create offset from agent pos
        alignmentMove = Vector3.SmoothDamp(agent.transform.forward, alignmentMove, ref currentVelocity, agentSmoothTime);
        return alignmentMove;
    }
}
