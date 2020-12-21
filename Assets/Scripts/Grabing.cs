using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabing : MonoBehaviour
{
    public Transform tempatPegangan;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;

        this.transform.position = tempatPegangan.position;
        this.transform.parent = GameObject.FindGameObjectWithTag("Crosair").transform;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;


    }
}
