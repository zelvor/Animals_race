using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    //IconPosition is a variable that will hold the position of the icon
    private Vector3 iconPosition;
    //Outside Position is a variable that will hold the position of the icon when it is outside the screen
    private Vector3 outsidePosition;
    //TMP text
    public TextMeshProUGUI PlayerTurnText;

    public TextMeshProUGUI WinnerPlayer;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;



    void Start()
    {
        //Set the icon position to the position of the icon
        iconPosition = GameObject.Find("IconPosition").transform.position;
        //Set the outside position to the position of the outside position
        outsidePosition = GameObject.Find("OutsidePosition").transform.position;
        WinnerPlayer.enabled = false;

        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        // P4.SetActive(false);
        
        //set all player active false
        for (int i = 1; i <= MenuController.numberOfPlayers; i++)
        {
            switch (i)
            {
                case 1:
                    P1.SetActive(true);
                    break;
                case 2:
                    P2.SetActive(true);
                    break;
                case 3:
                    P3.SetActive(true);
                    break;
                case 4:
                    P4.SetActive(true);
                    break;
            }
        }
    }
    void Update(){
        //Get player turn
        int playerTurn = Dice.playerTurn;
        GameObject.Find("P" + playerTurn).transform.position = iconPosition;
        PlayerTurnText.text = "Player " + playerTurn + "'s Turn";
        // all other players is outside the screen
        for (int i = 1; i <= GameController.maxPlayers; i++)
        {
            if (i != playerTurn)
            {
                GameObject.Find("P" + i).transform.position = outsidePosition;
            }
        }

        if (GameController.gameOver)
        {
            WinnerPlayer.text = "Player " + GameController.winnerPlayer + " Wins!";
            //set WinnerPlayer to active
            WinnerPlayer.enabled = true;
        }

        
    }
}
