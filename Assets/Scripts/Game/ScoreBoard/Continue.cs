using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    // Press anywhere to continue
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}
