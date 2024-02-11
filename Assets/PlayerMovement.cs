using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    float rotationSpeed = 400;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 MovementDirection = new Vector3(HorizontalInput, 0, VerticalInput);
        //MovementDirection.Normalize();
        transform.Translate(MovementDirection * moveSpeed * Time.deltaTime, Space.World);

        if (MovementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(MovementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
