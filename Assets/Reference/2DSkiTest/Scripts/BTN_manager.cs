using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BTN_manager : MonoBehaviour
{
    public GameObject sound;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        sound.SetActive(false);


    }
    public  void retur()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        sound.SetActive(true);
    }
    public void menu()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1f;
    }
}
