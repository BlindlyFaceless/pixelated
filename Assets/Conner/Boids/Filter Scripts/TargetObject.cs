using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Target")]
public class TargetObject : FilteredFlockBeahviour
{
    
    

    public override Vector3 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours maintain heading
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        //add all points together and average
        Vector3 moveTo = Vector3.zero;
        int goTo = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (item.CompareTag("Target"))
            {
                if (Vector3.Magnitude(item.position - agent.transform.position) < flock.SquareTargetRadius)
                {
                    FlockAgent.isInRange = true;
                    goTo++;
                    Vector3 follow = item.position;

                    moveTo += follow - agent.transform.position;

                }
            }
        }
        if(goTo > 0)
        {
            moveTo /= goTo;
        }




        return moveTo;
       
    }
}

