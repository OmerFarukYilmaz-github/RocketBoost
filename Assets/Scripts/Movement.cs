using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidbody;
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(Vector3.back);

        }
    }

    private void Rotate(Vector3 rotationDirection)
    {
        // objeye carpdiginda fizik dondurmesin sadece bizim rotasyonla hareket etsin
        rocketRigidbody.freezeRotation = true; 
        transform.Rotate(rotationDirection * Time.deltaTime * rotationPower);
        rocketRigidbody.freezeRotation = false;
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustPower);
        }

    }



}
