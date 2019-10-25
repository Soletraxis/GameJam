using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPiont : MonoBehaviour
{

    public float radius = 5.0f;
    public float power = 10.0f;
    public float upLift = 1.0f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Detonate();
        }
    }
    public void Detonate()
    {
        Vector3 explosionPoint = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, radius);
        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPoint, radius,upLift);
            }
        }
    }
}
