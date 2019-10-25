using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 1;
    private Rigidbody playerBody;
    private RaycastHit target;

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
                /*PlayerMovement(playerIndex);
                PlayerRTrig(playerIndex);
                PlayerBButton(playerIndex);
                PlayerLTrig(playerIndex);*/
                break;
        }
    }

    private void FixedUpdate()
    {
        FindTargetAction();
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

    private void FindTargetAction()
    {
        Physics.Raycast(transform.position, Vector3.forward, out target);
    }

    private void CastRaycast(string slowOrHaste)
    {
        Debug.DrawLine(transform.position, target.point);
        TimeChangeableObject Hitted = target.collider.GetComponent<TimeChangeableObject>();

        if (Hitted != null)
        {
            ImplementSlowOrHaste(slowOrHaste, Hitted);
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
