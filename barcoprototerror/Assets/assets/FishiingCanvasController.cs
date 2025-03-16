using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishiingCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishingInfoCanvas;
    public GameObject monsterPrefab; // Asigna el prefab del monstruo en el Inspector
    public Transform spawnPoint; // Punto donde aparecerá el monstruo
    public void CloseCanvas()
    {
        // Cierra el canvas
        fishingInfoCanvas.SetActive(false);

        // Instancia y activa el monstruo
        if (monsterPrefab != null && spawnPoint != null)
        {
            GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
            monster.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCanvas();
        }
    }
}
