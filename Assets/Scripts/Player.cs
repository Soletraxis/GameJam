using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 1;
    public float acceleration = 20f;
    public float topspeed = 30f;
    public float turningspeed = 5;
    public float wheelMaxRotation = 30f;
    private Rigidbody playerBody;
    private TimeChangeableObject target;

    [SerializeField] private List<WheelCollider> allWheels = new List<WheelCollider>();
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
            wheel.motorTorque = vertical * Time.deltaTime * acceleration;
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
            CastRaycast("haste");
        }
    }

    private void PlayerBButton(int index)
    {
        if (Input.GetAxis("BButton" + index) > 0.0f)
        {
            CastRaycast("slow");
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
}
