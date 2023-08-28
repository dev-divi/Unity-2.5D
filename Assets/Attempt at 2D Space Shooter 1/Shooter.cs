//Attack.cs 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public GameObject target; 
    public float turnSpeed = 5.0f;
    public float flightSpeed = 0.3f; 

    float distanceToTarget; 
    string state = "ATTACK"; 

    // Start is called before the first frame update
    void LookAt2D(Vector3 targetPos)
    { 
        Vector3 dir = targetPos - this.transform.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; 
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward); 

        this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = (target.transform.position - this.transform.position).magnitude; 
        //if(distanceToTarget > 10) {
        //    state = "ATTACK"; 
        //}
        //else if(distanceToTarget < 2) { 
            //state = "RETREAT"; 
        //}
        //if(state == "ATTACK ") { 
            LookAt2D(target.transform.position); 
            this.transform.Translate(Vector3.up * flightSpeed); 
        //}
        //else { 
        //    this.transform.Translate(Vector3.up * flightSpeed); 
        //}
    }

}
