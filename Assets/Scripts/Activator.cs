using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject Gate, Transision;

    void OnCollisionEnter(Collision gate)
    {
        if(gate.gameObject.name == "Cube (1)")
        {
            Debug.Log("Gate");
            Gate.SetActive(false);
            Transision.SetActive(true);
            Destroy(gate.gameObject);
        }


    }
}
