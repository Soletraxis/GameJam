using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderForPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TimeChangeableObject>())
        {
            TimeChangeableObject pierdole = other.gameObject.GetComponent<TimeChangeableObject>();
            if (isObjectHiddenByObstacle(pierdole))
            {
                return;
            }

            GetComponentInParent<Player>().setTarget(pierdole);

        }
    }
    bool isObjectHiddenByObstacle(TimeChangeableObject pierdole)
    {
        float distanceToPlayer = Vector3.Distance(GetComponentInParent<TimeChangeableObject>().transform.position, pierdole.TimeChangeableObjectBody.position);
        RaycastHit[] hits = Physics.RaycastAll(GetComponentInParent<TimeChangeableObject>().transform.position, pierdole.TimeChangeableObjectBody.position - GetComponentInParent<TimeChangeableObject>().transform.position, distanceToPlayer);

        foreach (RaycastHit hit in hits)
        {
            // ignore the enemy's own colliders (and other enemies)
            if (hit.transform.tag == "Player")
                continue;

            // if anything other than the player is hit then it must be between the player and the enemy's eyes (since the player can only see as far as the player)
            if (hit.transform.tag != "TimeChangeableObject")
            {
                return true;
            }
        }
        // if no objects were closer to the enemy than the player return false (player is not hidden by an object)
        return false;

    }
}
