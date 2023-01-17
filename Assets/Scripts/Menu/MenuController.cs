using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField inputField;
    public static int numberOfPlayers = 2;
    // button Play, load Game scene
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void GetNumberOfPlayers()
    {
        numberOfPlayers = int.Parse(inputField.text);
        Debug.Log(numberOfPlayers);
        //if numberOfPlayers from 1 to 4, then load Game scene
        if (numberOfPlayers >= 1 && numberOfPlayers <= 4)
        {
            Play();
        }else{
            Debug.Log("Number of players must be from 1 to 4");
            //Input field is empty
            inputField.text = "";
        }
    }


}
