using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //public GameObject pauseMenu;
    //private bool isPaused = true;

    public float fuerza = 2;

    public Color defaultColor;
    public Color newColor;
    public RenderBuffer render;

    public AudioClip toque;
    AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioS = GetComponent<AudioSource>();
        // if (prefab)
        //     newObj = Instantiate(prefab, new Vector3(0, 3, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

        //if(Input.GetKeyDown(KeyCode.Return) && !newObj)
            //newObj = Instantiate(prefab, new Vector3(0, 3, 0), Quaternion.identity);


        RaycastHit hitInfo;
        Ray Myray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Myray, out hitInfo, 100.0f))
            {
                if (hitInfo.transform != null)
                {
                    Rigidbody rb;

                    if (rb = hitInfo.transform.GetComponent<Rigidbody>())
                    {
                        rb.AddForce(-hitInfo.normal * fuerza, ForceMode.Impulse);
                        audioS.PlayOneShot(toque, 5f);
                    }
                }
            }
        }
    }

    public void TogglePause() 
    {

        /*if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 1.0f : 0.0f;
        }*/
    
    }

    public void MenuInicio() {

        SceneManager.LoadScene("MainMenu");

    }

    public void Inicio() {

        SceneManager.LoadScene("CharacterFirstPerson");
    }

    public void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material.color = Color.black;
    }

    public void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
