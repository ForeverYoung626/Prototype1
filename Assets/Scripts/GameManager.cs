using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pause;
    public GameObject pausePanel;


    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CheckPause();
        }

    }

    void CheckPause()
    {
        pause = !pause;
        pausePanel.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }
}
