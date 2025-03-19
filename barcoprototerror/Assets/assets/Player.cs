using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ImpulseSpeed = 3f;
    public float rotateAngle = 100f;
    private bool isInFishingZone = false;
    private Rigidbody rb;
    private FishingSpot currentFishingSpot; // Referencia al pozo actual
    public GameObject fishingQTECanvas;
    public GameObject fishingInfoCanvas;
    public PointerController fishingQTE; // Referencia al script del QTE
    public GameObject gameOverCanvas;
    public GameObject victoryCanvas;
    public Collider portCollider; // Referencia al collider del puerto
    private bool monsterAppeared = false; // Para controlar si el monstruo ya salió

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f; // Para que el bote desacelere naturalmente

        if (portCollider != null)
        {
            portCollider.enabled = false; // Desactivar el puerto al inicio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            isInFishingZone = true;
            currentFishingSpot = other.GetComponent<FishingSpot>(); // Guardar referencia al pozo
            Debug.Log("Estas en un pozo de pesca.");
        }
        if (other.CompareTag("Monster"))
        {
            Debug.Log("¡Te atrapó el monstruo!");
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
        }
        else if (other.CompareTag("Port") && monsterAppeared)
        {
            Debug.Log("¡Llegaste al puerto!");
            victoryCanvas.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FishingZone"))
        {
            isInFishingZone = false;
            currentFishingSpot = null; // Resetear referencia
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
            fishingQTECanvas.SetActive(true);
            fishingQTE.StartFishing(); // Activa el QTE correctamente
        }
        else
        {
            Debug.LogError("ERROR: FishingQTE no está asignado en el Inspector.");
        }
    }

    public void CompleteFishing()
    {
        fishingQTECanvas.SetActive(false);

        if (currentFishingSpot != null)
        {
            if (currentFishingSpot.fishingResultCanvas != null)
            {
                currentFishingSpot.fishingResultCanvas.SetActive(true); // Activar el canvas correspondiente
            }
            else
            {
                Debug.LogError("ERROR: No hay un canvas asignado a este pozo de pesca.");
            }

            // Desactivar el pozo de pesca después de completar el QTE
            currentFishingSpot.gameObject.SetActive(false);
        }
    }

    public void EnablePort()
    {
        if (portCollider != null)
        {
            portCollider.enabled = true; // Habilitar el puerto cuando aparezca el monstruo
            monsterAppeared = true;
            Debug.Log("¡El puerto ahora está abierto!");
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
