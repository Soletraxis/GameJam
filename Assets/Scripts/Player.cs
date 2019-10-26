﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 1;

    public float slowTargetStrenght = 0.1f;
    public float speedTargetStrenght = 0.3f;
    public float slowTargetTime = 5f;
    public float speedTargetTime = 3f;
    public float acceleration = 10f;
    public float topspeed = 30f;
    public float turningspeed = 5;
    public float Torque = 10000;
    public float wheelMaxRotation = 30f;
    private Rigidbody playerBody;
    private int loopNumber = 1;
    private TimeChangeableObject target;
//<<<<<<< HEAD

    [SerializeField] public List<WheelCollider> allWheels = new List<WheelCollider>();
//=======
    private List<Checkpoint> passedCheckpoint = new List<Checkpoint>();
   
//>>>>>>> master
    [SerializeField] public List<WheelCollider> frontWheels = new List<WheelCollider>();

    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        state = State.Normal;
    }

    public State state;
    public enum State
    {
        Normal,   
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                PlayerMovement(playerIndex);
                PlayerBButton(playerIndex);
                PlayerAButton(playerIndex);
                break;
        }
    }

    private void PlayerMovement(int index)
    {
        float horizontal = Input.GetAxis("Horizontal" + index);
        float verticalGo = Input.GetAxis("RTrig" + index);
        float verticalStop = -Input.GetAxis("LTrig" + index);
        float brake = Input.GetAxis("CButton" + index);
        float vertical = verticalGo + verticalStop;

        foreach (WheelCollider wheel in frontWheels)
        {
            wheel.motorTorque = vertical * Time.deltaTime * acceleration * Torque;
            wheel.brakeTorque = 4 * brake * Time.deltaTime * acceleration;
            wheel.steerAngle = turningspeed * horizontal;
            if(wheel.steerAngle >= wheelMaxRotation)
            {
                wheel.steerAngle = wheelMaxRotation;
            }
            else if(wheel.steerAngle <= -wheelMaxRotation)
            {
                wheel.steerAngle = -wheelMaxRotation;
            }
        }
    }

    private void PlayerAButton(int index)
    {
        if (Input.GetAxis("AButton" + index) > 0.0f)
        {
            if (target != null)
            {
                Debug.Log(target.gameObject.name.ToString());
                TimeChangeReflect TCR = target.gameObject.GetComponent<TimeChangeReflect>();
                {
                    TCR.SlowSth(slowTargetTime, slowTargetStrenght);
                }
            }
        }
    }

    private void PlayerBButton(int index)
    {
        if (Input.GetAxis("BButton" + index) > 0.0f)
        {
            if (target != null)
            {
                TimeChangeReflect TCR = target.gameObject.GetComponent<TimeChangeReflect>();
                {
                    TCR.FastSth(speedTargetTime, speedTargetStrenght);
                }
            }
        }
    }

    public void setTarget(TimeChangeableObject Target)
    {
        target = Target;
    }


    private void CastRaycast(string slowOrHaste)
    {
        if (target != null)
        {
            ImplementSlowOrHaste(slowOrHaste, target);
        }
    }

    private void ImplementSlowOrHaste(string slowOrHaste, TimeChangeableObject Hitted)
    {
        switch(slowOrHaste)
        {
            case "slow":
                Hitted.slow();
                break;
            case "haste":
                Hitted.haste();
                break;
        }
    }

    public void OnPassedCheckpoint(Checkpoint checkpoint)
    {
        passedCheckpoint.Add(checkpoint);
    }

    public bool isPlayerCapableToFinish(Checkpoint checkpoint)
    {
        return checkpoint.getNumberOfCheckpoints() == passedCheckpoint.Count + 1;
    }
    public void resetCheckpoints()
    {

        foreach (Checkpoint checkpoint in passedCheckpoint)
        {
            checkpoint.resetCheckpointStatus(this);
        }
        passedCheckpoint.Clear();
        loopNumber += 1;
        print("loop: "+loopNumber);
    }
}
