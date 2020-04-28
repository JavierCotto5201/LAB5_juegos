using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float score = 0;
    public Text scoreText;
    public Slider vol;
    public AudioClip disparo;
    public AudioClip puntos;
    public AudioClip pasos;
    AudioSource audioS;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioS.PlayOneShot(disparo);
            RaycastHit hitInfo;
            Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(MyRay, out hitInfo))
            {
                BoxCollider bc = hitInfo.collider as BoxCollider;

                if (bc != null) 
                {
                    Destroy(bc.gameObject);                  
                    score++;
                    audioS.PlayOneShot(puntos, 0.5f);
                }

            }

            if (scoreText)
                scoreText.text = "Score: " + score.ToString();
        }            
    }
}
