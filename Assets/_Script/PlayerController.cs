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

    //Flashlight object
    [SerializeField]
    GameObject flashlight;

    [SerializeField]
    float interactRange;

    Vector3 deltaDir;

    //Input Validity Flag -> Used to block during stuns/cinematics/etc
    public bool inputFrozen = true;
    
    //Pause Flag
    bool gamePaused = false;

    Rigidbody playRigid;

    float pitch = 0;

    HidingSpot curSpot;

    public bool isHiding = false;

    public void InitializeCharacter()
    {
        playRigid = GetComponent<Rigidbody>();

        //Ensure input is valid
        inputFrozen = false;
     
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
            //Collect Movement Input
            float zInput = Input.GetAxisRaw("Vertical");
            float xInput = Input.GetAxisRaw("Horizontal");

            deltaDir = transform.forward * zInput + transform.right * xInput;
            deltaDir = deltaDir.normalized;

            //Collect Camera Input
            float xMouse = Input.GetAxis("Mouse X");

            //Reference player rotation from start of frame
            Vector3 transEuler = transform.eulerAngles;

            //Apply mouse input to player rotation on y axis
            transEuler.y += xMouse * turnSpeed * Time.deltaTime;

            transform.eulerAngles = transEuler;

            pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y"), -60, 60);
            playCam.localRotation = Quaternion.Euler(pitch, 0, 0);

        
            //If Flashlight input pressed
            if(Input.GetKeyDown(KeyCode.F))
            {
                //Toggle flashlight activation
                flashlight.SetActive(!flashlight.activeSelf);
            }
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (curSpot == null)
                {
                    RaycastHit hit;

                    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

                    // actual Ray
                    Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

                    if (Physics.Raycast(ray, out hit, interactRange))
                    {
                        // our Ray intersected a collider
                        if (hit.collider.tag == "Hiding Spot")
                        {
                            curSpot = hit.collider.GetComponent<HidingSpot>();
                            curSpot.HideAtSpot(transform, playCam);
                            isHiding = true;
                        }
                    }
                }
                else
                {
                    curSpot.StopHidingAtSpot();
                    curSpot = null;

                    playCam.localEulerAngles = Vector3.zero;

                    pitch = 0;

                    isHiding = false;
                }
            }
        }

        
    }

    private void FixedUpdate()
    {
        playRigid.velocity = deltaDir * moveSpeed;
    }
}
