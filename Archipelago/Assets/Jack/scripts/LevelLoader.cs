using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition = null;
    public GameObject loadingScreen = null;
    public Slider slider = null;

    bool loading = false;

    [HideInInspector] public InputMaster controls = null;

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.Player.Interact.performed += context => StartGame();
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Player.Interact.performed -= context => StartGame();
        controls.Disable();
    }





    private void Start()
    {
        loading = false;
    }


    public void StartGame()
    {
        if (!loading && SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
            loading = true;
        }
    }
    

    IEnumerator LoadAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }

        transition.SetTrigger("Start");
    }

}
