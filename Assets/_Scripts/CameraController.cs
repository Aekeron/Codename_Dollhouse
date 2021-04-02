using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float movespeed;

    [SerializeField]
    float turnspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 deltaDir = (transform.forward * zInput + transform.right * xInput).normalized;

        transform.position += deltaDir * movespeed * Time.deltaTime;

        Vector3 euler = transform.eulerAngles;

        euler.y += Input.GetAxis("Mouse X") * turnspeed * Time.deltaTime;
        euler.x += Input.GetAxis("Mouse Y") * -turnspeed * Time.deltaTime;

        transform.eulerAngles = euler;
    }
}