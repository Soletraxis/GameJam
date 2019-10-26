using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distanceTravelled;
    public float chillwagonOffset;
    public float slowTimeSpeed = 0.2f;
    public float slowTimeDialation = 3f;
    public float TimeDial = 0f;

    public float cooldownTime = 0;

    bool invoke = false;

    public float cooldownInitial = 5f;

    bool triggered = false;

    void Update()
    {
        cooldownTime--;
        if (triggered) TimeDial--;
        float offset = chillwagonOffset + GetComponentInParent<ChillPociag>().GetTrainOffset();

        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + offset);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + offset);

        if (invoke)
        {
            if (triggered)
            {
                speed *= slowTimeSpeed;

                triggered = false;
                TimeDial = slowTimeDialation;
            }

        }else
        {
            speed /= slowTimeSpeed;
        }
        
    }

    public void SlowTrain()
    {
        if(cooldownTime < 0)
        {
            triggered = true;
        }
    }
}
