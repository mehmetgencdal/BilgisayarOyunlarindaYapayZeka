using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    private float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime;
        transform.position += new Vector3(0, vertical, 0) * Time.deltaTime;
    }
}
