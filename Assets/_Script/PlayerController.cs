using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    Transform playCam;

    public bool inputFrozen = true;

    public void InitializeCharacter()
    {
        inputFrozen = false;
        transform.position = new Vector3(0.347f, 0f, 0.977f);
        Destroy(GetComponent<Animator>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputFrozen)
        {
            float zInput = Input.GetAxisRaw("Vertical");
            float xInput = Input.GetAxisRaw("Horizontal");

            float xMouse = Input.GetAxis("Mouse X");
            float yMouse = -Input.GetAxis("Mouse Y");


            Vector3 deltaDir = ((transform.forward * zInput) + (transform.right * xInput)).normalized;
            transform.position += deltaDir * moveSpeed * Time.deltaTime;

            Vector3 camEuler = playCam.localEulerAngles;
            Vector3 transEuler = transform.eulerAngles;

            camEuler.x += yMouse * turnSpeed * Time.deltaTime;

            camEuler.x = Mathf.Clamp(camEuler.x, -40, 40);

            transEuler.y += xMouse * turnSpeed * Time.deltaTime;

            playCam.localEulerAngles = camEuler;
            transform.eulerAngles = transEuler;
        }
    }
}
