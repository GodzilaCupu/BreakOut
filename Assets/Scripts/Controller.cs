using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject cameraOld, cameraNew, pannelWin, pannelLoose, pintu1, pintu2;

    public Animator animLaser;


    // Update is called once per frame
    void Update()
    {
        Controlller();
    }


    void Controlller()
    {
        //Controller
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cameraNew.SetActive(true);
            cameraOld.SetActive(false);
        }
        else
        {
            cameraNew.SetActive(false);
            cameraOld.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision Coll)
    {
        Debug.Log("Test");
        if (SceneManager.GetActiveScene().name == "1")
        {
            if (Coll.gameObject.name == "VentCover")
            {
                Debug.Log("Vent");
                Destroy(Coll.gameObject);
            }

            if (Coll.gameObject.name == "Laser")
            {
                Debug.Log("Laser");
                pannelLoose.SetActive(true);
                Time.timeScale = 0 ;
            }

            if (Coll.collider.CompareTag("pintu1"))
            {
                Destroy(pintu1);
                Destroy(pintu2);
            }
        } else
        if (SceneManager.GetActiveScene().name == "1-1")
        {

         
        }

    }

}
