using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public static int numberOfPlayers = 2;

    public GameObject p1Name;
    public GameObject p2Name;
    public GameObject p3Name;
    public GameObject p4Name;

    public static string p1NameText;
    public static string p2NameText;
    public static string p3NameText;
    public static string p4NameText;

    void Start()
    {
        //set all player name input field inactive
        p1Name.SetActive(false);
        p2Name.SetActive(false);
        p3Name.SetActive(false);
        p4Name.SetActive(false);
    }

    public void GetNumberOfPlayers(int val)
    {
        //get number of players from dropdown
        if (val == 0)
        {
            numberOfPlayers = 2;
        }
        else if (val == 1)
        {
            numberOfPlayers = 3;
        }
        else if (val == 2)
        {
            numberOfPlayers = 4;
        }
    }
    public void ShowPlayerInput(){
        //active player name input field
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            switch (i)
            {
                case 1:
                    p1Name.SetActive(true);
                    break;
                case 2:
                    p2Name.SetActive(true);
                    break;
                case 3:
                    p3Name.SetActive(true);
                    break;
                case 4:
                    p4Name.SetActive(true);
                    break;
            }
        }
    }

    public void SetPlayerName(){
        //set player name from input field TMPro
        p1NameText = p1Name.transform.GetChild(1).GetComponent<TMP_InputField>().text;
        p2NameText = p2Name.transform.GetChild(1).GetComponent<TMP_InputField>().text;
        p3NameText = p3Name.transform.GetChild(1).GetComponent<TMP_InputField>().text;
        p4NameText = p4Name.transform.GetChild(1).GetComponent<TMP_InputField>().text;
    }
    
    public void LoadScene(){
        //load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame(){
        //quit game
        Application.Quit();
    }
}
