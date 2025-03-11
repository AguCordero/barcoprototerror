using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointerController : MonoBehaviour
{
    public RectTransform pointer;
    public RectTransform pointA;
    public RectTransform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 500f;

    private Vector2 targetPosition;
    private bool isFishing = false;

    void Start()
    {
        gameObject.SetActive(false); // El QTE inicia desactivado
    }

    void Update()
    {
        if (!isFishing) return;

        // Mover el pointer entre PointA y PointB
        pointer.anchoredPosition = Vector2.MoveTowards(pointer.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

        // Cambiar dirección al llegar a un punto
        if (Vector2.Distance(pointer.anchoredPosition, pointA.anchoredPosition) < 5f)
        {
            targetPosition = pointB.anchoredPosition;
        }
        else if (Vector2.Distance(pointer.anchoredPosition, pointB.anchoredPosition) < 5f)
        {
            targetPosition = pointA.anchoredPosition;
        }

        // Si el jugador presiona espacio, verifica si acierta
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }

    public void StartFishing()
    {
        gameObject.SetActive(true);
        isFishing = true;
        pointer.anchoredPosition = pointA.anchoredPosition;
        targetPosition = pointB.anchoredPosition;
    }

    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointer.position, null))
        {
            Debug.Log("¡Pez atrapado!");
        }
        else
        {
            Debug.Log("¡El pez escapó!");
        }

        EndFishing();
    }

    public void EndFishing()
    {
        isFishing = false;
        gameObject.SetActive(false);
    }
}