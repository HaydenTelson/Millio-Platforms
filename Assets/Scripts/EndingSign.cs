using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSign : MonoBehaviour
{
    public static bool endingMenuActive = false;
    public GameObject endingUI;
    
    // private void Start() 
    // {
    //     endingUI.SetActive(false);
    //     Time.timeScale = 1f;
    //     endingMenuActive = false;   
    // }
    
    private void Awake() 
    {
        endingUI.SetActive(false);
        Time.timeScale = 1f;
        endingMenuActive = false;   
    }

    private void OnTriggerEnter2D() 
    {
        endingUI.SetActive(true);
        Time.timeScale = 0f;
        endingMenuActive = true;
    }

    private void OnTriggerStay2D() 
    {
        //endingUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        endingUI.SetActive(false);
        endingMenuActive = false;
    }

    public void RestartGame()
    {
        LevelManager.instance.Respawn();
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
