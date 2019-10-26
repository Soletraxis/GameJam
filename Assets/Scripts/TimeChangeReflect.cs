﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeReflect : MonoBehaviour
{
    Rigidbody rigidbody;

    float SlowEffectTime = 10.0f;
    
    bool first = false;
    bool second = false;

    float duration0 = 0f;
    float duration1 = 0f;
    float duration2 = 0f;
    float duration3 = 0f;

    float timeStrenght0 = 1f;
    float timeStrenght1 = 1f;
    float timeStrenght2 = 1f;
    float timeStrenght3 = 1f;

    bool invoke0 = false;
    bool invoke1 = false;
    bool invoke2 = false;
    bool invoke3 = false;

    bool first0 = false;
    bool first1 = false;
    bool first2 = false;
    bool first3 = false;

    float time = 0;
    public float TimeScale = 0.2f;

    bool slowMO = false;
    bool fastMO = false;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        rigidbody = GetComponent<Rigidbody>();
    }
   
  
  
    private void SlowMe(float slowDuration, float slowStrenght)
    {
        duration0 = slowDuration;
        timeStrenght0 = slowStrenght;
        invoke0 = true;
    }

    public void SlowSth(float slowDuration, float slowStrenght)
    {
        duration1 = slowDuration;
        timeStrenght1 = slowStrenght;
        invoke1 = true;
    }

    private void FastMe(float fastDuration, float fastStrenght)
    {
        duration2 = fastDuration;
        timeStrenght2 = fastStrenght;
        invoke2 = true;
    }

    public void FastSth(float fastDuration, float fastStrenght)
    {
        duration3 = fastDuration;
        timeStrenght3 = fastStrenght;
        invoke3 = true;

    }


    

    void Update()
    {
        slowMO = Input.GetKey(KeyCode.Z);
        fastMO = Input.GetKey(KeyCode.C);

        time += Time.deltaTime;

        if (invoke0) duration0 -= Time.deltaTime;
        if (invoke1) duration1 -= Time.deltaTime;
        if (invoke2) duration2 -= Time.deltaTime;
        if (invoke3) duration3 -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        //FUNKCJA SLOW ME
        if(invoke0)
        {
            
            if (!first0)
            {
                rigidbody.mass /= timeStrenght0;
                rigidbody.velocity *= timeStrenght0;
                rigidbody.angularVelocity *= timeStrenght0;
                rigidbody.useGravity = false;
            }

            float dt = Time.fixedDeltaTime * timeStrenght0;

            rigidbody.AddForce(Vector3.down * Mathf.Abs(Physics.gravity.magnitude) * rigidbody.mass * timeStrenght0 * timeStrenght0);


            if (duration0 <= 0) invoke0 = false;
            first0 = true;

        }else if(first0)
        {

            float dt = Time.fixedDeltaTime * timeStrenght0;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= timeStrenght0;
            rigidbody.velocity /= timeStrenght0;
            rigidbody.angularVelocity /= timeStrenght0;


            first0 = false;
        }
        //FUNKCJA SLOW STH
        if (invoke1)
        {
            if (!first1)
            {
                rigidbody.mass /= timeStrenght1;
                rigidbody.velocity *= timeStrenght1;
                rigidbody.angularVelocity *= timeStrenght1;
                rigidbody.useGravity = false;
            }

            float dt = Time.fixedDeltaTime * timeStrenght0;

            rigidbody.AddForce(Vector3.down * Mathf.Abs(Physics.gravity.magnitude) * rigidbody.mass * timeStrenght1 * timeStrenght1);


            if (duration1 <= 0) invoke1 = false;
            first1 = true;

        }
        else if (first1)
        {

            float dt = Time.fixedDeltaTime * timeStrenght1;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= timeStrenght1;
            rigidbody.velocity /= timeStrenght1;
            rigidbody.angularVelocity /= timeStrenght1;


            first1 = false;
        }
        // FUNKCJA FAST ME
        if (invoke2)
        {
            if (!first2)
            {
                rigidbody.mass *= timeStrenght2;
                rigidbody.velocity /= timeStrenght2;
                rigidbody.angularVelocity /= timeStrenght2;
                rigidbody.useGravity = false;
            }
            float dt = Time.fixedDeltaTime / timeStrenght2;

            rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / timeStrenght2 / timeStrenght2);


            if (duration2 <= 0) invoke2 = false;
            first2 = true;

        }
        else if (first2)
        {

            float dt = Time.fixedDeltaTime / timeStrenght2;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= timeStrenght2;
            rigidbody.velocity *= timeStrenght2;
            rigidbody.angularVelocity *= timeStrenght2;


            first2 = false;
        }
        // FUNKCJA FAST STH
        if (invoke3)
        {
            if (!first3)
            {
                rigidbody.mass *= timeStrenght3;
                rigidbody.velocity /= timeStrenght3;
                rigidbody.angularVelocity /= timeStrenght3;
                rigidbody.useGravity = false;
            }
            float dt = Time.fixedDeltaTime / timeStrenght3;

            rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / timeStrenght3 / timeStrenght3);


            if (duration3 <= 0) invoke3 = false;
            first3 = true;

        }
        else if (first3)
        {
            float dt = Time.fixedDeltaTime / timeStrenght3;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= timeStrenght3;
            rigidbody.velocity *= timeStrenght3;
            rigidbody.angularVelocity *= timeStrenght3;



            first3 = false;
        }




        // Slowing down on Z
        if (slowMO)
        {
            if(!first)
            {
                rigidbody.mass /= TimeScale;
                rigidbody.velocity *= TimeScale;
                rigidbody.angularVelocity *= TimeScale;
                rigidbody.useGravity = false;
            }
            float dt = Time.fixedDeltaTime * TimeScale;
            
            rigidbody.AddForce(Vector3.down*Mathf.Abs(Physics.gravity.magnitude)*rigidbody.mass*TimeScale*TimeScale);
            
                                       
            first = true;
        }
        else if(first)
        {
            
            float dt = Time.fixedDeltaTime * TimeScale;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= TimeScale;
            rigidbody.velocity /= TimeScale;
            rigidbody.angularVelocity /= TimeScale;
            
            first = false;
        }


        //Fasting Up on C
        if (fastMO)
        {
            if (!second)
            {
                rigidbody.mass *= TimeScale;
                rigidbody.velocity /= TimeScale;
                rigidbody.angularVelocity /= TimeScale;
                rigidbody.useGravity = false;
            }
            float dt = Time.fixedDeltaTime / TimeScale;

            rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / TimeScale / TimeScale);


            second = true;
        }
        else if (second)
        {

            float dt = Time.fixedDeltaTime / TimeScale;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= TimeScale;
            rigidbody.velocity *= TimeScale;
            rigidbody.angularVelocity *= TimeScale;

            second = false;
        }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 100), "Velovity    " + rigidbody.velocity.magnitude.ToString());
        GUI.Label(new Rect(0, 15, 500, 100), "Mass    " + rigidbody.mass.ToString());
        GUI.Label(new Rect(0, 30, 500, 100), "TimeScale    " + Time.timeScale.ToString());
        GUI.Label(new Rect(0, 45, 500, 100), "Z    " + (Input.GetKey(KeyCode.Z) ? "1":"0"));
        GUI.Label(new Rect(0, 60, 500, 100), "AngularVelocity    " + rigidbody.angularVelocity.magnitude.ToString(),ToString());
        GUI.Label(new Rect(0, 75, 500, 100), "Accel" + rigidbody.velocity.magnitude/(time),ToString());

    }
}