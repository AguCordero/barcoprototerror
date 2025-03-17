using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo vuelve a la normalidad
        SceneManager.LoadScene("MainMenu"); // Reemplaza "MainMenu" con el nombre real de tu escena de menú
    }
}
