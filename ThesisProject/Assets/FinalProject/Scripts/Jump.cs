using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Rigidbody characterRB; // Reference to the Rigidbody component of the character
    private float jumpheight = 25f;
    private RaycastHit airborneCheck;
    float distance = 1f;
    // Start is called before the first frame update
    void Start()
    {
characterRB = GetComponent<Rigidbody>(); // Getting the Rigidbody component attached to the character
    }

    // Update is called once per frame


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), distance))
            {
                transform.position += new Vector3(0, 1, 0) * jumpheight * Time.deltaTime;
            }
        }
    }
}
