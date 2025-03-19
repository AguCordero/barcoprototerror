using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Asigna el transform del jugador en el Inspector
    public float speed = 5f; // Velocidad de movimiento del monstruo
    public AudioSource screamSound;
    private bool isChasing = false;
    private Player playerScript; // Referencia al script del jugador

    public void AppearMonster()
    {
        // Aquí va la lógica para hacer aparecer al monstruo (habilitarlo, hacerlo visible, etc.)
        Debug.Log("¡El monstruo ha aparecido!");

        // Llamar a EnablePort() del jugador (o algún otro controlador que maneje el puerto)
        Player player = FindObjectOfType<Player>(); // Encontrar al jugador en la escena
        if (player != null)
        {
            player.EnablePort();  // Habilitar el puerto ahora que el monstruo ha aparecido
        }
    }

    void Start()
    {
        // Si el AudioSource está asignado, lo reproducimos cuando el monstruo aparece
        if (screamSound != null)
        {
            screamSound.Play();
        }
        AppearMonster();
        playerScript = FindObjectOfType<Player>(); // Busca al jugador en la escena
    }

    public void StartChase()
    {
        isChasing = true;

        if (playerScript != null)
        {
            playerScript.EnablePort(); // Habilita el puerto cuando el monstruo empieza a perseguir
            Debug.Log("¡El puerto se ha activado!");
        }
        else
        {
            Debug.LogError("No se encontró el Player para habilitar el puerto.");
        }


    }

    void Update()
    {
        // Verifica que el jugador esté asignado
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mueve al monstruo hacia el jugador
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
