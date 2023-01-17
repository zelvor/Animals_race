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

    void Start()
    {
        //Set the icon position to the position of the icon
        iconPosition = GameObject.Find("IconPosition").transform.position;
        //Set the outside position to the position of the outside position
        outsidePosition = GameObject.Find("OutsidePosition").transform.position;
        //disable WinnerPlayer
        WinnerPlayer.enabled = false;
    
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
            WinnerPlayer.enabled = true;
        }

        
    }
}
