using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliumBalloon : MonoBehaviour
{
    //The force that pulls the balloon up
    public float force = 0.15f;

    private Rigidbody balloonRigidbody;

    void Start() {
        balloonRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        balloonRigidbody.AddForce(0f, force, 0f, ForceMode.Force);
    }
}
