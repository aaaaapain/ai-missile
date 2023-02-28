using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class missle : MonoBehaviour
{
    public Transform missleTarget;
    public Rigidbody missleRgb;

    public float turnSpeed = 1f;
    public float rocketFlySpeed = 5f;

    private Transform rocketLocalTrans;

    void Start()
    {
        rocketLocalTrans = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        missleRgb.velocity = rocketLocalTrans.forward * rocketFlySpeed;
        var rocketTargetRot = Quaternion.LookRotation(missleTarget.position - rocketLocalTrans.position);

        missleRgb.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, turnSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

}