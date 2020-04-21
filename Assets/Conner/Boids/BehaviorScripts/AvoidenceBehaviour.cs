using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidence")]
public class AvoidenceBehaviour : FilteredFlockBeahviour
{
    public override Vector3 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours maintain heading
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        //add all points together and average
        Vector3 avoidenceMove = Vector3.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if(Vector3.SqrMagnitude(item.position-agent.transform.position ) > flock.SquareAvoidenceRadius)
            {
                nAvoid++;
                avoidenceMove += (agent.transform.position - item.position);
            }
           
        }
        if (nAvoid > 0)
        {
            avoidenceMove /= nAvoid;
        }
           

        return avoidenceMove;
    }
}
