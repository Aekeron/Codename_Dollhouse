using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //How fast player moves
    [SerializeField]
    float moveSpeed;

    //How fast player turns
    [SerializeField]
    float turnSpeed;

    //Player Camera
    [SerializeField]
    Transform playCam;

    //NPC view Camera
    [SerializeField]
    Transform secondCam;

    //Flashlight object
    [SerializeField]
    GameObject flashlight;

    //Input Validity Flag -> Used to block during stuns/cinematics/etc
    public bool inputFrozen = true;
    
    //Pause Flag
    bool gamePaused = false;

    //Second Camera Active Flag
    bool secondCamActive = false;

    public void InitializeCharacter()
    {
        //Ensure input is valid
        inputFrozen = false;
        //Set player into start position
        transform.position = new Vector3(0.347f, 0f, 0.977f);
        //Destroy unneeded Components
        Destroy(GetComponent<Animator>());

        //Lock cursor to middle of screen and disable visual
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        //If Pause input pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused == false)
            {
                //Unlock mouse and pause game
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gamePaused = true;
                inputFrozen = true;
            }
            else
            {
                //Lock mouse and unpause game
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gamePaused = false;
                inputFrozen = false;
            }
        }

        //If input is valid
        if (!inputFrozen)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                //Switch Cameras
                secondCamActive = !secondCamActive;

                playCam.gameObject.SetActive(!secondCamActive);
                secondCam.gameObject.SetActive(secondCamActive);
            }
            
            //Collect Movement Input
            float zInput = Input.GetAxisRaw("Vertical");
            float xInput = Input.GetAxisRaw("Horizontal");

            //Collect Camera Input
            float xMouse = Input.GetAxis("Mouse X");
            float yMouse = -Input.GetAxis("Mouse Y");

            //Utilize movement input to calculate direction
            Vector3 deltaDir = ((transform.forward * zInput) + (transform.right * xInput)).normalized;
            //Apply movement in direction, with steady movespeed
            transform.position += deltaDir * moveSpeed * Time.deltaTime;
            

            //Reference camera rotation from start of frame
            Vector3 camEuler = playCam.localEulerAngles;
            //Reference player rotation from start of frame
            Vector3 transEuler = transform.eulerAngles;

            //Apply mouse input to camera rotation on x axis
            camEuler.x += yMouse * turnSpeed * Time.deltaTime;
            //Clamp rotation between desired rotations
            camEuler.x = Mathf.Clamp(camEuler.x, -40, 40);

            //Apply mouse input to player rotation on y axis
            transEuler.y += xMouse * turnSpeed * Time.deltaTime;

            //Apply camera and player rotations to transforms
            playCam.localEulerAngles = camEuler;
            transform.eulerAngles = transEuler;

            //If Flashlight input pressed
            if(Input.GetKeyDown(KeyCode.F))
            {
                //Toggle flashlight activation
                flashlight.SetActive(!flashlight.activeSelf);
            }          
        }
    }
}
