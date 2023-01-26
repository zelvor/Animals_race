using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    // Press anywhere to continue

    public GameObject scoreBoard;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            scoreBoard.SetActive(false);
            // Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}
