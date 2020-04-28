using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cancion : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider vol;
    public AudioSource song;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        song.volume = vol.value;
    }
}
