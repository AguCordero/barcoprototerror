using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Asigna el transform del jugador en el Inspector
    public float speed = 5f; // Velocidad de movimiento del monstruo

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
