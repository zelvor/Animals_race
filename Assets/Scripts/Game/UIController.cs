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

    public GameObject player;
    public GameObject playerGhost;

    void Start()
    {
        //Set the icon position to the position of the icon
        iconPosition = GameObject.Find("IconPosition").transform.position;
        //Set the outside position to the position of the outside position
        outsidePosition = GameObject.Find("OutsidePosition").transform.position;

        for (int i = 0; i < MenuController.numberOfPlayers; i++)
        {
            player = GameObject.Find("Player " + (i + 1));
            playerGhost = GameObject.Find("P" + (i+1) + "_Ghost");
            playerGhost.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Movement>().playerName;
        }

        //set active false for all other players
        for (int i = MenuController.numberOfPlayers; i < 4; i++)
        {
            GameObject.Find("P" + (i+1) + "_Ghost").SetActive(false);
        }

    }
    void Update(){
        //Get player turn
        int playerTurn = Dice.playerTurn;
        GameObject.Find("P" + playerTurn).transform.position = iconPosition;
        //show player turn = name's turn
        PlayerTurnText.text = GameObject.Find("Player " + playerTurn).GetComponent<Movement>().playerName + "'s turn";
        // all other players is outside the screen
        for (int i = 1; i <= GameController.maxPlayers; i++)
        {
            if (i != playerTurn)
            {
                GameObject.Find("P" + i).transform.position = outsidePosition;
            }
        }      
    }
}
