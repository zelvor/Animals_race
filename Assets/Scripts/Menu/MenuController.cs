using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField inputField;
    // button Play, load Game scene
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void GetNumberOfPlayers()
    {
        int numberOfPlayers = int.Parse(inputField.text);
        Debug.Log(numberOfPlayers);
    }


}
