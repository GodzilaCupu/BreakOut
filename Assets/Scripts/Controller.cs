using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject cameraOld, cameraNew, pannelWin, pannelLoose, pintu1, pintu2;

    public Animator gantiScene;


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
                GantiScence();
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

            if (Coll.gameObject.name == "SummonStage2")
            {
                SceneManager.LoadScene("Level 2");
            }

        } else
        if (SceneManager.GetActiveScene().name == "1-1")
        {

            if (Coll.collider.CompareTag("papan"))
            {
                Destroy(GameObject.FindWithTag("papan"));
            }

            if (Coll.collider.CompareTag("katanyaAir"))
            {
                SceneManager.LoadScene("1-1");
                Debug.Log("Lab2");
            }

            if (Coll.collider.CompareTag("Lift"))
            {
                GantiScence();
            }



        }else if ( SceneManager.GetActiveScene().name == "Level 2")
        {
            if (Coll.collider.CompareTag("Tuas"))
            {
                Debug.Log("testing");
            }
        }

    }

    public void GantiScence()
    {

        StartCoroutine(Ganti(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator Ganti (int level)
    {
        gantiScene.SetTrigger("Ganti");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(level);
    }

}
