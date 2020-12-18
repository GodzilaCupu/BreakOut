using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject[] pintu;
    public GameObject[] laser;
    public GameObject[] cube;

    public Rigidbody[] rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (GameObject.FindGameObjectWithTag("pintu1"))
        {
            rb[0].AddForce(transform.forward * 500f);
            rb[0].useGravity = true;
            rb[1].AddForce(transform.forward * 500f);
            rb[1].useGravity = true;
        }
    }
}
