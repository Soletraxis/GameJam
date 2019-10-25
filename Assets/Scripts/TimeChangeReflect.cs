using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeReflect : MonoBehaviour
{
    Rigidbody rigidbody;
    bool first = false;
    public float TimeScale = 0.2f;
    bool slowMO = false;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
    }

   

    void Update()
    {
        slowMO = Input.GetKey(KeyCode.Z);
        
    }

    void FixedUpdate()
    {
        if (slowMO)
        {
            float dt = Time.fixedDeltaTime * TimeScale;
            rigidbody.velocity -= Physics.gravity * dt;
            rigidbody.mass /= TimeScale;
            rigidbody.velocity *= TimeScale;
            rigidbody.angularVelocity *= TimeScale;
            rigidbody.rotation.Set(rigidbody.rotation.x * TimeScale, rigidbody.rotation.y * TimeScale, rigidbody.rotation.z * TimeScale, rigidbody.rotation.w * TimeScale);
                                        
            first = true;
        }
        else if(first)
        {
            float dt = Time.fixedDeltaTime * TimeScale;
            rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= TimeScale;
            rigidbody.velocity /= TimeScale;
            rigidbody.angularVelocity /= TimeScale;
            rigidbody.rotation.Set(rigidbody.rotation.x / TimeScale, rigidbody.rotation.y / TimeScale, rigidbody.rotation.z / TimeScale, rigidbody.rotation.w / TimeScale);

            first = false;
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 100), "Velovity    " + rigidbody.velocity.magnitude.ToString());
        GUI.Label(new Rect(0, 15, 500, 100), "Mass    " + rigidbody.mass.ToString());
        GUI.Label(new Rect(0, 30, 500, 100), "TimeScale    " + Time.timeScale.ToString());
        GUI.Label(new Rect(0, 40, 500, 100), "Z    " + (Input.GetKey(KeyCode.Z) ? "1":"0"));

    }
}
