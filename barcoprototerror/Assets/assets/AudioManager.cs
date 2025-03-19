using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambientSound;

    // Start is called before the first frame update
    void Start()
    {
        if (ambientSound != null)
        {
            ambientSound.loop = true;
            ambientSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
