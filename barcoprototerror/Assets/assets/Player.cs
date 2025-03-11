using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ImpulseSpeed = 3f;
    public float rotateAngle = 100f;
    private bool isInFishingZone = false;
    private Rigidbody rb;

    public PointerController fishingQTE; // Referencia al script del QTE

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f; // Para que el bote desacelere naturalmente
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            isInFishingZone = true;
            Debug.Log("Estas en un pozo de pesca.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            isInFishingZone = false;
        }
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            Impulse();
        }

        Rotate(Input.GetAxisRaw("Horizontal"));

        // Activar QTE si el jugador está en la zona de pesca y presiona "E"
        if (isInFishingZone && Input.GetKeyDown(KeyCode.E))
        {
            Fish();
        }
    }

    void Fish()
    {
        Debug.Log("¡Iniciando QTE de pesca!");

        if (fishingQTE != null)
        {
            fishingQTE.StartFishing(); // Activa el QTE correctamente
        }
        else
        {
            Debug.LogError("ERROR: FishingQTE no está asignado en el Inspector.");
        }
    }

    private void Impulse()
    {
        rb.velocity += transform.forward * ImpulseSpeed * Time.deltaTime;
    }

    private void Rotate(float rotateDirection)
    {
        var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle * Time.deltaTime, Vector3.up);
        transform.forward = rotation * transform.forward;
    }
}
