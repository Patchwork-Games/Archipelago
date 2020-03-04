using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject CompassUI;

    [HideInInspector] public InputMaster controls = null;


    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.Player.Pause.performed += context => CheckPause();
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Player.Pause.performed -= context => CheckPause();
        controls.Disable();
    }






    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }




    public void CheckPause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        } 
    }





    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        if(PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.BOAT) StaticValueHolder.DashMeterObject.gameObject.GetComponent<Canvas>().enabled = true; //only show if in boat
        CompassUI.SetActive(true);
        StaticValueHolder.PlayerMovementScript.jump = false;
        StaticValueHolder.PlayerMovementScript.interact = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        StaticValueHolder.DashMeterObject.gameObject.GetComponent<Canvas>().enabled = false;
        CompassUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
