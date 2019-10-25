using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 1;
    private Rigidbody playerBody;

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

    private void FixedUpdate()
    {
        
    }

    private void PlayerMovement(int index)
    {
        float horizontal = Input.GetAxis("Horizontal" + index);
        float vertical = Input.GetAxis("Vertical" + index);
        Debug.Log(horizontal);
    }

    private void PlayerRTrig(int index)
    {
        if(Input.GetAxis("RTrig" + index) > 0.0f)
        {
            
        }
    }

    private void PlayerLTrig(int index)
    {
        if (Input.GetAxis("LTrig" + index) > 0.0f)
        {

        }
    }

    private void PlayerBButton(int index)
    {
        if (Input.GetAxis("BButton" + index) > 0.0f)
        {
            
        }
    }
}
