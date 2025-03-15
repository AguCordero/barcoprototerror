using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishiingCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishingInfoCanvas;

    public void CloseCanvas()
    {
        fishingInfoCanvas.SetActive(false);
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
