using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{

    TimeChangeReflect TCR;
    public float TCScale = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        TCR = this.gameObject.GetComponent<TimeChangeReflect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = TCScale;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1.0f;
            
        }
    }
}
