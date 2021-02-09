using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteract : MonoBehaviour
{
    public static bool controlMenuActive = false;
    public GameObject canvasUI;
    
    private void Start() 
    {
        canvasUI.SetActive(false);
        Time.timeScale = 1f;
        controlMenuActive = false;   
    }

    private void OnTriggerEnter2D() 
    {
        canvasUI.SetActive(true);
        controlMenuActive = true;
    }

    private void OnTriggerStay2D() 
    {
        // if(Input.GetKeyDown(KeyCode.E))
        // {
        //     canvasUI.SetActive(true);
        //     Time.timeScale = 0f;
        //     controlMenuActive = true;
            
        // }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        canvasUI.SetActive(false);
        controlMenuActive = false;
    }
}
