using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 1;
    private Rigidbody playerBody;
    private TimeChangeableObject target;

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
                PlayerRTrig(playerIndex);
                PlayerBButton(playerIndex);
                PlayerLTrig(playerIndex);
                break;
        }
    }

    private void PlayerMovement(int index)
    {
        float horizontal = Input.GetAxis("Horizontal" + index);
        float vertical = Input.GetAxis("Vertical" + index);
    }

    private void PlayerRTrig(int index)
    {
        if(Input.GetAxis("RTrig" + index) > 0.0f)
        {
            CastRaycast("slow");
        }
    }

    private void PlayerLTrig(int index)
    {
        if (Input.GetAxis("LTrig" + index) > 0.0f)
        {
            CastRaycast("haste");
        }
    }

    private void PlayerBButton(int index)
    {
        if (Input.GetAxis("BButton" + index) > 0.0f)
        {
            
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
