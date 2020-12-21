using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // deklarasi kecepatan player
    public float speed = 12f;
    // deklarasi gravity
    public float gravity = -9.81f;

    // deklarasi GroundCheck Component
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask Envirotment;
    public bool isGround;

    // deklarasi ketinggian Loncat
    public float tinggiLoncat = 3f;

    // deklarasi komponen chacartercontroler
    public CharacterController player;

    // deklarasi velocity untuk menyimpan nilai ketinggian;
    Vector3 velocity;
    
    public GameObject cameraOld,cameraNew,pannelWin,pannelLoose;
    public Animator anim;


    private void Update()
    {
        PlayerMovement();
        Controlller();
    }

    private void FixedUpdate()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, Envirotment);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void PlayerMovement()
    {

        // mengambil value dari input horizontal dan di simpan pada dirX, vertical di simpan pada dirZ
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        // membuat kalkulasi untuk bergerak ketika terdapat sebuah input
        Vector3 gerak = transform.right * dirX + transform.forward * dirZ;

        // menggerakan player sesuai dengan input dan kecepatan
        player.Move(gerak * speed * Time.deltaTime);

        // mengecek ketinggian 
        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
        // fungsi untuk loncat
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(tinggiLoncat * -2f * gravity);
            Debug.Log("Loncat");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            player.Move(gerak * speed * 3 * Time.deltaTime);

        }
    }

    void Controlller()
    { 
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Level 2");
        }   

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

    private void OnTriggerEnter(Collider other)
    {
        


    }


    void OnCollisionEnter(Collision Coll)
    {
        Debug.Log("Test");
        if(SceneManager.GetActiveScene().name == "1")
        {
            if (Coll.gameObject.name == "VentCover")
            {
                Debug.Log("Vent");
                Destroy(Coll.gameObject);
            }

            if(Coll.gameObject.name == "Laser")
            {
                Debug.Log("Laser");
                pannelLoose.SetActive(true);
            }
        }

    }

    public void fadetolavel(int levelIndex)
    {
        anim.SetTrigger("Transisison");
    }
}
