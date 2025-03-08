using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ImpulseSpeed = 3f;
    public float rotateAngle = 100f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            Impulse();
        }

        Rotate(Input.GetAxisRaw("Horizontal"));

    }

    private void Impulse()
    {
        rb.velocity += transform.forward * ImpulseSpeed * Time.deltaTime;
    }

    private void Rotate(float rotateDirection)
    {
        var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle *Time.deltaTime, Vector3.up);
        transform.forward = rotation * transform.forward;
    }    
}
